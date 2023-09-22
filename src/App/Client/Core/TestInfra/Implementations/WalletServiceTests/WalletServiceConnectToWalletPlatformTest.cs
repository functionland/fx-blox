using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.TestInfra.Implementations.WalletServiceTests
{
    public partial class WalletServiceConnectToWalletPlatformTest : PlatformTest
    {
        [AutoInject] protected IWalletService WalletService { get; set; } = default!;
        public override string Title => "WalletServiceConnecToWallet";
        public override string Description => "WalletServiceConnecToWallet";
        protected override async Task OnRunAsync()
        {
            await WalletService.ConnectAsync(EthereumChain.Goerli);
        }
    }
}
