using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    public record WifiInfo
    {
        public required string Ssid { get; set; }
        public required string Essid { get; set; }
        public required int Rssi { get; set; }
    }
}
