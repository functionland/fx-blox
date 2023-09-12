using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations;

public partial class BloxConnectionFactory
{
    [AutoInject]
    public IServiceProvider ServiceProvider { get; set; }

    /// <summary>
    /// You should dispose the connection yourself.
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    public BloxConnection Create(BloxDevice device)
    {
        var hotspotClientFactory = ServiceProvider.GetRequiredService<BloxWifiHotspotClientFactory>();
        var libp2pClientFactory = ServiceProvider.GetRequiredService<BloxLibp2pClientFactory>();

        var hotspotClient = hotspotClientFactory.Create(device);
        var libp2pClient = libp2pClientFactory.Create(device);

        var connection = new BloxConnection(device, hotspotClient, libp2pClient);
        return connection;
    }
}