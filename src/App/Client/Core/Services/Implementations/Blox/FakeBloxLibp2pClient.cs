using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;

namespace Functionland.FxBlox.Client.Core.Services.Implementations;

public class FakeBloxLibp2pClient : IBloxLibp2pClient
{
    public BloxDevice Device { get; private set; } = default!;

    public void Initialize(BloxDevice device)
    {
        Device = device;
    }

    public async Task ConnectAsync(CancellationToken cancellationToken)
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