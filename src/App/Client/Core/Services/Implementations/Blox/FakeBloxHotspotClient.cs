using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public partial class FakeBloxHotspotClient : IBloxHotspotClient
    {
        [AutoInject] IWifiService WifiService { get; set; } = default!;
        public BloxDevice Device { get; private set; } = default!;
        

        public async Task<BloxInfo> GetBloxInfoAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            return new BloxInfo() { HardwareId = "a48b2b11c2f44fc3a103c7daa8bf4dd4a96d9e5d65a027404a269de29d50dbbf" };
        }

        public void Initialize(BloxDevice device)
        {
            Device = device;
        }

        public async Task<string> ExchangeAsync(string peerId, string seed, CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            return "blox-peer-Id-65464";
        }

        public async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken)
        {
            var wifiList = await WifiService.GetWifiListAsync(cancellationToken);
            var result = wifiList.Where(w => !w.Ssid.Contains("Blox")).ToList();
            return result;
        }

        public async Task ConnectToWifiAsync(string ssid, string? password, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }

        public async Task<bool> GetStatusAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            return true;
        }

        public void Dispose()
        {

        }
    }
}
