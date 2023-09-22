using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IWifiService
    {
        Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default);
        Task ConnectAsync(WifiInfo hotspot);
    }
}
