namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class MyDevice
    {
        [AutoInject] private IBloxConnectionService BloxConnectionService { get; set; } = default!;
        private bool _applyAnimation = false;


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
    }
}