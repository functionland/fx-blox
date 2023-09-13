namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class MyDevice
    {
        private bool _applyAnimation = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
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