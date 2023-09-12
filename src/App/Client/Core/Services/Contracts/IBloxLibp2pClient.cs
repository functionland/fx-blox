using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IBloxLibp2pClient : IDisposable
{
    BloxDevice Device { get; }
    Task InitializeAsync(CancellationToken cancellationToken);
    Task<bool> CheckConnectionAsync(CancellationToken cancellationToken);

}