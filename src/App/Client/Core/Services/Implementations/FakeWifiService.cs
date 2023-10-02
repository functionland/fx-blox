using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public class FakeWifiService : IWifiService
    {
        public virtual async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);

            return new List<WifiInfo>()
            {
                new()
                {
                    Ssid = "Blox (Mock)",
                    Essid = "11:c9:6c:ff:ee:11",
                    Rssi = -17
                },
                new()
                {
                    Ssid = "Afshin Home",
                    Essid = "66:32:b1:cf:7e:16",
                    Rssi = -57
                },
                new()
                {
                    Ssid = "Mehran Work",
                    Essid = "c5:af:b1:11:36:6b",
                    Rssi = -12
                },
                new()
                {
                    Ssid = "Functionland 1",
                    Essid = "22:c9:6c:ff:ee:22",
                    Rssi = -17
                },
                new()
                {
                    Ssid = "Functionland 3",
                    Essid = "33:c9:6c:ff:ee:33",
                    Rssi = -17
                }
            };
        }

        public async Task ConnectAsync(WifiInfo hotspot)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
}
