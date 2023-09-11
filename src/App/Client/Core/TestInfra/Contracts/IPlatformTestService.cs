using Functionland.FxBlox.Client.Core.TestInfra.Implementations;

namespace Functionland.FxBlox.Client.Core.TestInfra.Contracts
{
    public interface IPlatformTestService
    {
        event EventHandler<TestProgressChangedEventArgs>? TestProgressChanged;

        IEnumerable<IPlatformTest> GetTests();
        Task RunTestAsync(IPlatformTest platformTest);
    }
}
