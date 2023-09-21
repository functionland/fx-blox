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
        public async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);

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
                    Essid = "Blox 11",
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
    }
}
