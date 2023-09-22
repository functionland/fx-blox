

using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Components;

public partial class BloxAddWizard
{
    [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
    [AutoInject] private BloxConnectionFactory BloxConnectionFactory { get; set; } = default!;
    [AutoInject] private IWifiService WifiService { get; set; } = default!;
    public BloxAddWizardStep WizardStep { get; set; } = BloxAddWizardStep.Welcome;
    public string? SelectedNetwork { get; set; }
    public string? SelectedWifiForBlox { get; set; }
    public List<ProgressItem> ProgressItems { get; set; } = new();

    private BloxConnection? BloxConnection { get; set; }
    public List<BitDropdownItem> AvailableWifiList { get; set; } = new();

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

        Progress($"Blox found: '{hotspot.Essid}'.", progressType: ProgressType.Done);

        Progress("Connecting to directly Blox hotspot...", createNew: true);

        await WifiService.ConnectAsync(hotspot);

        Progress("Connected to Blox hotspot.", progressType: ProgressType.Done);

        var device = new BloxDevice
        {
            HotspotInfo = hotspot,
            Title = hotspot.Essid
        };
        
        BloxConnection = await BloxConnectionService.CreateForDeviceAsync(device);

        Progress($"Loading hardware information from: '{device.Title}'...", createNew: true);
        await BloxConnectionService.LoadDeviceInfoAsync(BloxConnection);
        Progress($"Hardware information loaded from: '{device.Title}'.", ProgressType.Done);
        
        Progress($"Loading available Wi-Fi(s) near '{device.Title}'...", createNew: true);
        var wifiListOfBlox = await BloxConnection.GetWifiListAsync();
        AvailableWifiList = wifiListOfBlox
                            .Select(w => new BitDropdownItem()
                            {
                                Value = w.Ssid, 
                                Text = w.Essid,
                                Data = w
                            })
                            .ToList();

        Progress($"Found {wifiListOfBlox.Count} Wi-Fi(s) near '{device.Title}'.", ProgressType.Done);

        await Task.Delay(TimeSpan.FromSeconds(2));
        //await GoToNextStepAsync();

    }

    public async Task ConnectBloxToWifiClicked()
    {
        if (SelectedWifiForBlox is null)
        {
            // ToDo: Ask user to select one
            return;
        }

        if (BloxConnection is null)
        {
            throw new InvalidOperationException("BloxConnection is null");
        }

        // ToDo: Ask for password in a popup
        var password = "123";

        Progress("Configuring the Blox Wi-Fi...");

        var ssid = SelectedWifiForBlox;
        await BloxConnection.ConnectBloxToWifiAsync(ssid, password);
        // Now we have lost the connection to the blox via hotspot.

        Progress("Connecting to Blox via blockchain (Libp2p)...");
        await BloxConnection.ConnectToLibp2pAsync();

        Progress("Checking the Blox Libp2p connection...");
        var status = await BloxConnection.CheckLibp2pConnectionAsync();

        Progress("Connected to Blox via blockchain successfully.");

        await Task.Delay(TimeSpan.FromSeconds(2));

        NavigationManager.NavigateTo("mydevice");
    }

    public enum BloxAddWizardStep
    {
        Welcome = 1,
        ConnectToWallet,
        ConnectToHotspot,
        ConnectBloxToWifi
    }

    private List<BitDropdownItem> GetBlockchainNetworks()
    {
        return new List<BitDropdownItem>
        {
            new()
            {
                Value = BlockchainNetwork.EthereumMainnet.ToString(),
                Text = "Ethereum Mainnet"
            },
            new()
            {
                Value = BlockchainNetwork.EthereumTestnet.ToString(),
                Text = "Ethereum Testnet"
            }

        };
    }
}
