using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public BloxConnection(BloxDevice device, IBloxWifiHotspotClient hotspotClient, IBloxLibp2pClient libp2pClient)
        {
            Device = device;
            HotspotClient = hotspotClient;
            Libp2pClient = libp2pClient;
        }
        public BloxDevice Device { get; set; }
        public List<BloxStack> Stacks { get; set; } = new();
        public IBloxWifiHotspotClient HotspotClient { get; set; }
        public IBloxLibp2pClient Libp2pClient { get; set; }

        public void Dispose()
        {
            HotspotClient.Dispose();
            Libp2pClient.Dispose();
        }
    }
}
