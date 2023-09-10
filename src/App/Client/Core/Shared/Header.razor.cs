namespace Functionland.FxBlox.Client.Core
{
    public partial class Header : IDisposable
    {
        private bool _disposed;
        private bool _isUserAuthenticated;

        [Parameter] public EventCallback OnToggleMenu { get; set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
        }

        private async Task ToggleMenu()
        {
            await OnToggleMenu.InvokeAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            _disposed = true;
        }
    }
}