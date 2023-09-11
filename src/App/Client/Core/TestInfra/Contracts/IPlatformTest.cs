using Functionland.FxBlox.Client.Core.TestInfra.Implementations;

namespace Functionland.FxBlox.Client.Core.TestInfra.Contracts
{
    public interface IPlatformTest
    {
        string Title { get; }
        string Description { get; }
        Task RunAsync();
        public event EventHandler<TestProgressChangedEventArgs> ProgressChanged;
    }
}
