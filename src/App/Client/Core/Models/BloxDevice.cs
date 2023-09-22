using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    public record BloxDevice
    {
        public string? HardwareId { get; set; }
        public string? Title { get; set; }
        public required WifiInfo HotspotInfo { get; set; }
    }
}
