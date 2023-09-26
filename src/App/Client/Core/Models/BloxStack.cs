using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;

namespace Functionland.FxBlox.Client.Core.Models
{
    /// <summary>
    /// Indicates a FxStack that is available on a Blox Device
    /// </summary>
    public class BloxStack
    {
        public required BloxDevice Device { get; set; }
        public required IFxStack Stack { get; set; }
        public BloxStackStatus? Status { get; set; }
        public decimal EthereumBalance { get; set; }
    }
}
