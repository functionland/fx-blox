using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IBloxConnectionService
{
    bool IsInitialized { get; set; }
    Task InitializeAsync(CancellationToken cancellationToken = default);
    List<BloxConnection> GetConnections(CancellationToken cancellationToken);
    BloxConnection CreateNew(BloxDevice device, CancellationToken cancellationToken);
    void RemoveConnection(BloxConnection connection, CancellationToken cancellationToken);
}