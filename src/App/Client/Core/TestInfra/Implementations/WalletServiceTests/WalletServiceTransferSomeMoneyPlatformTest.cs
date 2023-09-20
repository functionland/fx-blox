using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.TestInfra.Implementations.WalletServiceTests
{
    public partial class WalletServiceTransferSomeMoneyPlatformTest : PlatformTest
    {
        [AutoInject] protected IWalletService WalletService { get; set; } = default!;
        public override string Title => "WalletServiceTranserMoney";
        public override string Description => "WalletServiceTranserMoney";
        protected override async Task OnRunAsync()
        {
            await WalletService.TransferSomeMoneyAsync();
        }
    }
}
