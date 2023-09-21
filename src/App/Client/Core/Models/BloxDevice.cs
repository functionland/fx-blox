using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    public class BloxDevice
    {
        public string? HardwareId { get; set; }
        public string? Title { get; set; }
        public required WifiInfo WifiInfo { get; set; }
    }
}
