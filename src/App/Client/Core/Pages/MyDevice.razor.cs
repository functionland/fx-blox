using Functionland.FxBlox.Client.Core.BloxStacks.Implementations;
using Functionland.FxBlox.Client.Core.Models;

using Radzen.Blazor;
using System;

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

        protected override void OnInitialized()
        {
            base.OnInitialized();
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
                bloxStack.EthereumBalance = await GetBalance();
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
    }
}