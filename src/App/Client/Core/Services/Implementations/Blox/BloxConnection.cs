using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    /// <summary>
    /// This is the item that UI binds to
    /// </summary>
    public class BloxConnection : IDisposable
    {
        public BloxConnection(BloxDevice device, IBloxHotspotClient hotspotClient, IBloxLibp2pClient libp2pClient)
        {
            Device = device;
            HotspotClient = hotspotClient;
            Libp2pClient = libp2pClient;
        }

        public BloxDevice Device { get; set; }
        public List<BloxStack> Stacks { get; set; } = new();
        private IBloxHotspotClient HotspotClient { get; }
        private IBloxLibp2pClient Libp2pClient { get; }

        public ConnectionStatus Libp2pStatus { get; private set; } = ConnectionStatus.Disconnected;

        public BloxStatus? LastStatus { get; set; }

        public async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = new())
        {
            return await HotspotClient.GetWifiListAsync(cancellationToken);
        }

        public void Dispose()
        {
            HotspotClient.Dispose();
            Libp2pClient.Dispose();
        }

        public async Task<BloxInfo> GetDeviceInfoAsync(CancellationToken cancellationToken = default)
        {
            return await HotspotClient.GetBloxInfoAsync(cancellationToken);
        }

        public async Task ConnectBloxToWifiAsync(string ssid, string password, CancellationToken cancellationToken = default)
        {
            await HotspotClient.ConnectToWifiAsync(ssid, password, cancellationToken);
        }

        public async Task<ConnectionStatus> CheckLibp2pConnectionAsync(CancellationToken cancellationToken = default)
        {
            var status = await Libp2pClient.CheckConnectionAsync(cancellationToken);
            Libp2pStatus = status ? ConnectionStatus.Connected : ConnectionStatus.Disconnected;

            return Libp2pStatus;
        }

        public async Task ConnectToLibp2pAsync(CancellationToken cancellationToken = default)
        {
            await Libp2pClient.ConnectAsync(cancellationToken);
        }

        public async Task<BloxStatus> GetBloxStatusAsync(CancellationToken cancellationToken = default)
        {
            LastStatus = await Libp2pClient.GetBloxStatusAsync(cancellationToken);
            return LastStatus;
        }
    }
}
