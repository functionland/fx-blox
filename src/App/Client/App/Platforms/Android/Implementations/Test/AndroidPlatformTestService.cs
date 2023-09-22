
using Functionland.FxBlox.Client.App.Platforms.Android.PlatformTests;
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;
using Functionland.FxBlox.Client.Core.TestInfra.Implementations;
using Functionland.FxBlox.Client.Core.TestInfra.Implementations.WalletServiceTests;

namespace Functionland.FxBlox.Client.App.Platforms.Android.Implementations.Test;

public partial class AndroidPlatformTestService : PlatformTestService
{
    [AutoInject] public AndroidWalletServiceTransferSomeMoneyPlatformTest AndroidWalletServiceTransferSomeMoneyPlatformTest { get; set; } = default!;
    protected override List<IPlatformTest> OnGetTests()
    {
        return new List<IPlatformTest>()
        {
          AndroidWalletServiceTransferSomeMoneyPlatformTest
        };
    }
}
