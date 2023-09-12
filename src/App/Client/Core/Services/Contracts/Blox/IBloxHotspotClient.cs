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
        Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken);
        Task ConnectToWifiAsync(WifiInfo wifi, string password, CancellationToken cancellationToken);
        Task<bool> GetStatusAsync(CancellationToken cancellationToken);
        void Initialize(BloxDevice device);
    }
}
