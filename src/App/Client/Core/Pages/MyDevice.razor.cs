using System.Globalization;

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
            //var connection = await BloxConnectionService.CreateForDeviceAsync(new BloxDevice()
            //{
            //    HardwareId = "gadfjghsdfugaifjhsaslijfghsliujfhslfh",
            //    PeerId = "gadfjghsdfugaifjhsaslijfghsliujfhslfh",
            //    HotspotInfo = new WifiInfo() { Essid = "", Ssid = "", Rssi = 0 }
            //});

            //await connection.GetBloxStatusAsync();

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

        //chart
        Interpolation interpolation = Interpolation.Spline;
        string FormatAsUSD(object value)
        {
            return ((double)value).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
        }

        string FormatAsPercent(object value)
        {
            if (value != null)
            {
                return value.ToString() + "%";
            }

            return string.Empty;
        }


        DataItem[] revenue2020 = new DataItem[] {
        new DataItem
        {
            Hour = ("10"),
            Usage = 20
        },
        new DataItem
        {
            Hour = ("11"),
            Usage = 30
        },
        new DataItem
        {
            Hour = ("12"),
            Usage = 10
        },
        new DataItem
        {
            Hour = ("13"),
            Usage = 15
        },
        new DataItem
        {
            Hour = ("14"),
            Usage = 20
        },
        new DataItem
        {
            Hour = ("15"),
            Usage = 30
        },
    };
    }
    public class DataItem
    {
        public string Hour { get; set; }
        public double Usage { get; set; }
    }
}