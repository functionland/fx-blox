using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IBloxHotspotClient : IDisposable
    {
        BloxDevice Device { get; }
        Task<string> ExchangeAsync(string peerId, string seed, CancellationToken cancellationToken = default);
        Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default);
        Task ConnectToWifiAsync(string ssid, string password, CancellationToken cancellationToken = default);
        Task<bool> GetStatusAsync(CancellationToken cancellationToken = default);
        Task<BloxInfo> GetBloxInfoAsync(CancellationToken cancellationToken = default);
        void Initialize(BloxDevice device);
    }
}
