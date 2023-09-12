using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    /// <summary>
    /// This is the item that UI binds to
    /// </summary>
    public class BloxConnection : IDisposable

    {
    public required BloxDevice Device { get; set; }
    public List<BloxStack> Stacks { get; set; } = new();
    public required IBloxWifiClient WifiClient { get; set; }
    public required IBloxLibp2pClient Libp2pClient { get; set; }

    public void Dispose()
    {
        WifiClient.Dispose();
        Libp2pClient.Dispose();
    }
    }
}
