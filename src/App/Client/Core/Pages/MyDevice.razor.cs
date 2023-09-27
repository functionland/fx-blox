using System.Globalization;
using System.Timers;
using Functionland.FxBlox.Client.Core.BloxStacks.Implementations;
using Functionland.FxBlox.Client.Core.Models;

using Radzen.Blazor;
using System;
using Timer = System.Timers.Timer;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class MyDevice
    {
        [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
        [AutoInject] private IBloxStackManager BloxStackManager { get; set; } = default!;

        [AutoInject] private IEthereumService EthereumService { get; set; } = default!;

        [AutoInject] private IWalletService WalletService { get; set; } = default!;

        private bool _applyAnimation = false;

        private BloxConnection? CurrentConnection { get; set; }

        private IEnumerable<GaugeTickPosition> TickPositions = Enum.GetValues(typeof(GaugeTickPosition)).Cast<GaugeTickPosition>();
        private GaugeTickPosition TickPosition = GaugeTickPosition.Outside;

        protected override async Task OnInitAsync()
        {
            StartUpdatingStatus();

            await base.OnInitAsync();
        }

        private void StartUpdatingStatus()
        {
            var _ = Task.Run(async () =>
            {
                while (true)
                {
                    if (CurrentConnection != null)
                    {
                        await CurrentConnection.GetBloxStatusAsync();
                    }

                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        protected override async Task OnParamsSetAsync()
        {
            await RefreshBloxStatusesAsync();
            await base.OnParamsSetAsync();
        }

        private async Task RefreshBloxStatusesAsync()
        {
            CurrentConnection = BloxConnectionService.GetConnections().LastOrDefault();
            var connections = BloxConnectionService.GetConnections();
            foreach (var connection in connections)
            {
                if (connection.Libp2pStatus != ConnectionStatus.Connected)
                    await connection.ConnectToLibp2pAsync();

                await connection.GetBloxStatusAsync();
            }

            if (CurrentConnection != null && CurrentConnection.Stacks != null)
            {
                foreach (var stack in CurrentConnection.Stacks)
                {
                    _ = UpdateBalanceEvery10Sec(stack);
                }
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
                bloxStack.EthereumBalance = await GetBalance();
                _ = UpdateBalanceEvery10Sec(bloxStack);
                bloxStack.Status = BloxStackStatus.Running;
            }
            catch (Exception ex)
            {
                bloxStack.Status = BloxStackStatus.Faulted;
                // ToDo: Show exception
            }

            StateHasChanged();
        }

        private async Task<decimal> GetBalance()
        {
            var walletAddress = WalletService.GetCurrentAddress();
            var balance = (await EthereumService.GetEtherBalanceAsync(walletAddress.Address, walletAddress.ChainId))?.Balance ?? 1m;
            return Math.Truncate(balance * 1000000m) / 1000000m;
        }

        private async Task UpdateBalanceEvery10Sec(BloxStack bloxStack)
        {
            while (true)
            {
                try
                {
                    bloxStack.EthereumBalance = await GetBalance();
                }
                catch
                { }

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
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