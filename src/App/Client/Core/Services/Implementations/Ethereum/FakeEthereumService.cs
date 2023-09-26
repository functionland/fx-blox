using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Contracts.Standards.ERC20.ContractDefinition;
using Functionland.FxBlox.Client.Core.Models.Ethereum;
using Functionland.FxBlox.Client.Core.Services.Implementations.EthereumService;
using TokenListService = Functionland.FxBlox.Client.Core.Services.Implementations.EthereumService.TokenListService;
using Nethereum.Signer;

namespace Functionland.FxBlox.Client.Core.Services.Implementations.Ethereum
{
    public partial class FakeEthereumService : IEthereumService
    {

        public async Task<BalanceResult> GetEtherBalanceAsync(string account, string chainId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return new BalanceResult() { Balance = 1.2M, TokenName = "ETH" };
        }

        public async Task<BalanceResult> GetTokenBalancesAsync(string tokenName, string account, string chainId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return new BalanceResult() { Balance = 1.2M, TokenName = "ETH" };
        }
    }
}
