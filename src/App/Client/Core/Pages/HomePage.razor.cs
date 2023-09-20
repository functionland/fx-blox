using WalletConnectSharp.Core;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign.Models.Engine;

namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class HomePage
    {
        [AutoInject] private IWalletService WalletService { get; set; } = default!;
        private async Task ConnectToWallet()
        {
            var session = await WalletService.ConnectAsync("");

        }
    }
}
