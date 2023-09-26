using Functionland.FxBlox.Client.Core.BloxStacks.Implementations;
using Functionland.FxBlox.Client.Core.Models;

using Radzen.Blazor;

namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class MyDevice
    {
        [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
        [AutoInject] private IBloxStackManager BloxStackManager { get; set; } = default!;
        private bool _applyAnimation = false;

        private BloxConnection? CurrentConnection { get; set; }

        private IEnumerable<GaugeTickPosition> TickPositions = Enum.GetValues(typeof(GaugeTickPosition)).Cast<GaugeTickPosition>();
        private GaugeTickPosition TickPosition = GaugeTickPosition.Outside;

        protected override async Task OnInitAsync()
        {
            var connection = await BloxConnectionService.CreateForDeviceAsync(new BloxDevice()
            {
                HardwareId = "gadfjghsdfugaifjhsaslijfghsliujfhslfh",
                PeerId = "gadfjghsdfugaifjhsaslijfghsliujfhslfh",
                HotspotInfo = new WifiInfo() { Essid = "", Ssid = "", Rssi = 0 }
            });

            await connection.GetBloxStatusAsync();

            await base.OnInitAsync();
        }

        protected override async Task OnParamsSetAsync()
        {
            await RefreshBloxStatusesAsync();
            await base.OnParamsSetAsync();
        }

        private async Task RefreshBloxStatusesAsync()
        {
            CurrentConnection = BloxConnectionService.GetConnections().FirstOrDefault();
            var connections = BloxConnectionService.GetConnections();
            foreach (var connection in connections)
            {
                if (connection.Libp2pStatus != ConnectionStatus.Connected)
                    await connection.ConnectToLibp2pAsync();

                await connection.GetBloxStatusAsync();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                _applyAnimation = true;
                StateHasChanged();
            }
        }

        private async Task AddStackClicked()
        {
            if (CurrentConnection is null)
                return;

            var bloxStack = new BloxStack
            {
                Device = CurrentConnection.Device,
                Stack = new FakeRocketPoolStack(),
                Status = BloxStackStatus.None
            };

            CurrentConnection?.Stacks?.Add(bloxStack);

            bloxStack.Status = BloxStackStatus.Deploying;
            StateHasChanged();
            try
            {
                await BloxStackManager.DeployStackAsync(bloxStack);
                bloxStack.Status = BloxStackStatus.Running;
            }
            catch (Exception ex)
            {
                bloxStack.Status = BloxStackStatus.Faulted;
                // ToDo: Show exception
            }

            StateHasChanged();
        }
    }
}