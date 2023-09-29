using WalletConnectSharp.Core;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign.Models.Engine;

namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class HomePage
    {
        protected override Task OnInitAsync()
        {
            NavigationManager.NavigateTo("add-blox-wizard", false, true);
            return base.OnInitAsync();
        }
    }
}
