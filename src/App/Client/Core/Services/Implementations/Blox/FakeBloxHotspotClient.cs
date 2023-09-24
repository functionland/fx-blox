using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public class FakeBloxHotspotClient : IBloxHotspotClient
    {
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
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

            return new List<WifiInfo>()
            {
                new()
                {
                    Essid = "Afshin Home",
                    Ssid = "66:32:b1:cf:7e:16",
                    Rssi = -57
                },
                new()
                {
                    Essid = "Mehran Work",
                    Ssid = "c5:af:b1:11:36:6b",
                    Rssi = -12
                },
                new()
                {
                    Essid = "Functionland 1",
                    Ssid = "22:c9:6c:ff:ee:22",
                    Rssi = -17
                },
                new()
                {
                    Essid = "Functionland 2",
                    Ssid = "11:c9:6c:ff:ee:11",
                    Rssi = -17
                },
                new()
                {
                    Essid = "Functionland 3",
                    Ssid = "33:c9:6c:ff:ee:33",
                    Rssi = -17
                }
            };
        }

        public async Task ConnectToWifiAsync(string ssid, string password, CancellationToken cancellationToken)
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
