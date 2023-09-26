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

    public async Task ConnectAsync(string peerId, CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }

    private readonly Random _random = new();

    public async Task<BloxStatus> GetBloxStatusAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(300), cancellationToken);
        return new BloxStatus
        {
            CpuUsage = _random.Next(70, 85),
            MemoryUsage = _random.Next(30, 40)
        };
    }

    public async Task<bool> CheckConnectionAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        return true;
    }

    public void Dispose()
    {

    }
}