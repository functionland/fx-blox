using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations;

public class FakeBloxLibp2pClient : IBloxLibp2pClient
{
    public BloxDevice Device { get; }

    public FakeBloxLibp2pClient(BloxDevice device)
    {
        Device = device;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
    }

    public async Task<bool> CheckConnectionAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        return true;
    }

    public void Dispose()
    {

    }
}