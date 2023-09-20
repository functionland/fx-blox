

using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Components;

public partial class BloxAddWizard
{
    [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
    public BloxAddWizardStep WizardStep { get; set; } = BloxAddWizardStep.Welcome;
    public string? SelectedNetwork { get; set; }
    public string? SelectedWifi { get; set; }

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

    public async Task ConnectToHotspotClicked()
    {
        var device = new BloxDevice();
        // Connect to Wi-Fi and fill device info from the rest
        BloxConnection = await BloxConnectionService.CreateForDeviceAsync(device);

        var wifiList = await BloxConnection.GetWifiListAsync();
        AvailableWifiList = wifiList
                            .Select(w => new BitDropdownItem() { Value = w.Ssid, Text = w.Essid })
                            .ToList();

        //AvailableWifiList = new List<BitDropdownItem>
        //{
        //    new()
        //    {
        //        Value = BlockchainNetwork.EthereumMainnet.ToString(),
        //        Title = "Ethereum Mainnet"
        //    },
        //    new()
        //    {
        //        Value = BlockchainNetwork.EthereumTestnet.ToString(),
        //        Title = "Ethereum Testnet"
        //    }
        //};
        await GoToNextStepAsync();
    }

    public async Task ConnectBloxToWifiClicked()
    {
        // ask for password
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
