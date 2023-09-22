using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IBloxConnectionService
{
    bool IsInitialized { get; set; }
    Task InitializeAsync(CancellationToken cancellationToken = default);
    List<BloxConnection> GetConnections(CancellationToken cancellationToken = default);
    Task<BloxConnection> CreateForDeviceAsync(BloxDevice device, CancellationToken cancellationToken = new());
    Task RemoveConnectionAsync(BloxConnection connection, CancellationToken cancellationToken);
    Task LoadDeviceInfoAsync(BloxConnection connection, CancellationToken cancellationToken = default);
}