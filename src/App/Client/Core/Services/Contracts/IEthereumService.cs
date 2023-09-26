using Functionland.FxBlox.Client.Core.Models.Ethereum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IEthereumService
    {
        Task<BalanceResult> GetEtherBalanceAsync(string account, string chainId);
        Task<BalanceResult> GetTokenBalancesAsync(string tokenName, string account, string chainId);
    }
}
