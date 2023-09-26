using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models.Ethereum
{
    public class BalanceResult
    {
        public string TokenImage { get; set; }
        public string TokenName { get; set; }
        public decimal Balance { get; set; }
        public string TokenAdress { get; set; }
    }
}
