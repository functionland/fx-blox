
using Functionland.FxBlox.Client.App.Platforms.Windows.PlatformTests;
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;
using Functionland.FxBlox.Client.Core.TestInfra.Implementations;

namespace Functionland.FxBlox.Client.App.Platforms.Windows.Implementations.Test;

public partial class WindowsPlatformTestService : PlatformTestService
{
    [AutoInject] public WindowsWalletServiceTransferSomeMoneyPlatformTest WindowsWalletServiceTransferSomeMoneyPlatformTest { get; set; } = default!;
    [AutoInject] public WindowsWalletServiceConnectToWalletPlatformTest WindowsWalletServiceConnectToWalletPlatformTest { get; set; } = default!;

    protected override List<IPlatformTest> OnGetTests()
    {
        return new List<IPlatformTest>()
        {
            WindowsWalletServiceConnectToWalletPlatformTest,
            WindowsWalletServiceTransferSomeMoneyPlatformTest
        };
    }
}
