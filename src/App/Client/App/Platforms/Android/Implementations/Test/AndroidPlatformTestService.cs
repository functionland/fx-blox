
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;
using Functionland.FxBlox.Client.Core.TestInfra.Implementations;

namespace Functionland.FxBlox.Client.App.Platforms.Android.Implementations.Test;

public partial class AndroidPlatformTestService : PlatformTestService
{
    protected override List<IPlatformTest> OnGetTests()
    {
        return new List<IPlatformTest>()
        {
          
        };
    }
}
