

using Functionland.FxBlox.Client.Core.Enums;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Components;

public partial class BloxAddWizard
{
    [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
    [AutoInject] private BloxConnectionFactory BloxConnectionFactory { get; set; } = default!;
    [AutoInject] private IWifiService WifiService { get; set; } = default!;
    [AutoInject] private IWalletService WalletService { get; set; } = default!;
    public BloxAddWizardStep WizardStep { get; set; } = BloxAddWizardStep.Welcome;
    public BlockchainNetwork? SelectedNetwork { get; set; }
    public WifiInfo? SelectedWifiForBlox { get; set; }
    public List<ProgressItem> ProgressItems { get; set; } = new();
    private InputModal? _passwordModalRef;
    private FxToast _toastRef = default!;

    private BloxConnection? BloxConnection { get; set; }
    public List<ListItem<WifiInfo>> AvailableWifiList { get; set; } = new();

    private bool ShowConnectToWallet { get; set; } = true;
    public async Task GoToNextStepAsync()
    {
        WizardStep++;

        //switch (WizardStep)
        //{
        //    case BloxAddWizardStep.ConnectToHotspot:
        //    case BloxAddWizardStep.ConnectBloxToWifi:
        //        await LoadBloxAvailableWifiListAsync();
        //        break;
        //}
    }

    private void Progress(string? message = null, ProgressType? progressType = null, bool createNew = false)
    {
        ProgressItem progress;
        var existing = ProgressItems.LastOrDefault();

        if (createNew || existing is null)
        {
            progress = new ProgressItem(message ?? "", progressType: progressType ?? ProgressType.Running);
            ProgressItems.Add(progress);
        }
        else
        {
            progress = existing;
        }

        if (message is not null)
            progress.Title = message;

        if (progressType is not null)
            progress.ProgressType = progressType.Value;

        StateHasChanged();
    }

    public async Task ConnectToHotspotClicked()
    {
        Progress("Looking for your Blox Hotspot Wi-Fi...");
        var wifiList = await WifiService.GetWifiListAsync();
        var hotspot = wifiList.FirstOrDefault(w => w.IsBloxHotspot());
        if (hotspot is null)
        {
            // ToDo: Show Alert: No Blox hotspot found.
            Progress($"Blox not found. Turn on the Blox and try again.", ProgressType.Fail);
            return;
        }

        Progress($"Blox found: '{hotspot.Ssid}'.", progressType: ProgressType.Done);

        Progress("Connecting to directly Blox hotspot...", createNew: true);

        await WifiService.ConnectAsync(hotspot);

        Progress("Connected to Blox hotspot.", progressType: ProgressType.Done);

        var device = new BloxDevice
        {
            HotspotInfo = hotspot,
            Title = hotspot.Ssid
        };

        BloxConnection = await BloxConnectionService.CreateForDeviceAsync(device);

        var peerId = "app-peer-id-586454";
        var seed = "adgdlahasdkgjf";
        Progress($"Exchanging keys with Blox: '{device.Title}'...", createNew: true);
        await BloxConnection.ExchangeAsync(peerId, seed);
        Progress($"Exchanged keys with Blox: '{device.Title}'.", ProgressType.Done);

        Progress($"Loading hardware information from: '{device.Title}'...", createNew: true);
        await BloxConnectionService.LoadDeviceInfoAsync(BloxConnection);
        Progress($"Hardware information loaded from: '{device.Title}'.", ProgressType.Done);

        Progress($"Loading available Wi-Fi(s) near '{device.Title}'...", createNew: true);
        var wifiListOfBlox = await BloxConnection.GetWifiListAsync();
        AvailableWifiList = wifiListOfBlox
                            .Select(w => new ListItem<WifiInfo>(w))
                            .ToList();

        Progress($"Found {wifiListOfBlox.Count} Wi-Fi(s) near '{device.Title}'.", ProgressType.Done);

        ProgressItems.Clear();
        await GoToNextStepAsync();

    }

    public async Task ConnectBloxToWifiClicked()
    {
        if (SelectedWifiForBlox is null)
        {
            await _toastRef.HandleShow("", "Select a Wi-Fi first.", FxToastType.Info);

            return;
        }

        if (BloxConnection is null)
        {
            throw new InvalidOperationException("BloxConnection is null");
        }

        if (_passwordModalRef is null)
        {
            return;
        }

        var result = await _passwordModalRef.ShowAsync($"Enter password for \"{(SelectedWifiForBlox?.Ssid ?? "")}\"",
            string.Empty,
            string.Empty,
            "Enter password",
            "Connect",
            "Password:",
            FxTextInputType.Password,
            FxButtonSize.Stretch,
            true);

        string? password;

        if (result.ResultType == InputModalResultType.Confirm)
        {
            if (string.IsNullOrWhiteSpace(result.Result))
            {
                await _toastRef.HandleShow("Password is required.",
                    "Password can't be empty",
                    FxToastType.Error);
                return;
            }

            password = result.Result;
        }
        else
        {
            return;
        }

        Progress("Configuring the Blox Wi-Fi...");

        var ssid = SelectedWifiForBlox.Ssid;
        await BloxConnection.ConnectBloxToWifiAsync(ssid, password);
        Progress("Blox Wi-Fi configured.", ProgressType.Done);

        // Now we have lost the connection to the blox via hotspot.
        Progress("Connecting to Blox via blockchain (Libp2p)...", createNew: true);
        await BloxConnection.ConnectToLibp2pAsync();
        Progress("Connected to Blox via blockchain (Libp2p).", ProgressType.Done);

        Progress("Checking the Blox Libp2p connection...", createNew: true);
        var status = await BloxConnection.CheckLibp2pConnectionAsync();
        Progress("Connected to Blox via blockchain successfully.", ProgressType.Done);

        Progress("Navigating to Blox Home", createNew: true);
        await Task.Delay(TimeSpan.FromSeconds(2));

        ProgressItems.Clear();
        NavigationManager.NavigateTo("mydevice");
    }

    public enum BloxAddWizardStep
    {
        Welcome = 1,
        ConnectToWallet,
        ConnectToHotspot,
        ConnectBloxToWifi
    }

    private List<ListItem<BlockchainNetwork>> BlockchainNetworks { get; set; }
        = new()
        {
            new(BlockchainNetwork.EthereumTestnet),
            new(BlockchainNetwork.EthereumMainnet)
        };

    private string ToReadable(BlockchainNetwork network)
    {
        return network switch
        {
            BlockchainNetwork.EthereumMainnet => "Ethereum Mainnet",
            BlockchainNetwork.EthereumTestnet => "Ethereum Testnet",
            _ => throw new InvalidOperationException($"Unknown network to display: {network}")
        };
    }

    private async Task ConnectToWalletClicked()
    {
        if (SelectedNetwork is null)
        {
            await _toastRef.HandleShow("", "Select a blockchain network first.", FxToastType.Info);
            return;
        }

        Progress("Waiting for wallet approval...",progressType: ProgressType.Running);
        ShowConnectToWallet = false;

        try
        {
            await WalletService.ConnectAsync(SelectedNetwork.Value);
            Progress("Wallet approved.", ProgressType.Done);
            await Task.Delay(TimeSpan.FromSeconds(2));
            ProgressItems.Clear();
            await GoToNextStepAsync();
        }
        catch (Exception ex)
        {
            Progress("Connecting to wallet canceled.", progressType: ProgressType.Fail);
            ShowConnectToWallet = true;
        }
    }

    private void BlockchainNetworkClicked(ListItem<BlockchainNetwork> item)
    {
        BlockchainNetworks.ForEach(i => i.IsSelected = false);
        item.IsSelected = true;
        SelectedNetwork = item.Item;
    }


    private void WifiClicked(ListItem<WifiInfo> item)
    {
        AvailableWifiList.ForEach(i => i.IsSelected = false);
        item.IsSelected = true;
        SelectedWifiForBlox = item.Item;
    }

    private async Task CancelConnectToHotspotClicked()
    {
        await _toastRef.HandleShow("", "Can not cancel now.", FxToastType.Info);
    }

    private async Task CancelConnectToWalletClicked()
    {
        await _toastRef.HandleShow("", "Can not cancel now.", FxToastType.Info);
    }

    private async Task CancelConnectBloxToWifiClicked()
    {
        await _toastRef.HandleShow("", "Can not cancel now.", FxToastType.Info);
    }
}
