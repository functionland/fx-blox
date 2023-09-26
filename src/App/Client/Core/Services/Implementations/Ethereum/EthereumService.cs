using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Contracts.Standards.ERC20.ContractDefinition;
using Functionland.FxBlox.Client.Core.Models.Ethereum;
using Functionland.FxBlox.Client.Core.Services.Implementations.EthereumService;
using TokenListService = Functionland.FxBlox.Client.Core.Services.Implementations.EthereumService.TokenListService;
using Nethereum.Signer;

namespace Functionland.FxBlox.Client.Core.Services.Implementations.Ethereum
{
    public partial class EthereumService : IEthereumService
    {
        [AutoInject] private TokenListService TokenListService { get; set; } = default!;

        public async Task<BalanceResult> GetEtherBalanceAsync(string account, string chainId)
        {
            var web3 = GetWeb3(chainId);
            var etherBalance = Web3.Convert.FromWei(await web3.Eth.GetBalance.SendRequestAsync(account));
            return new BalanceResult() { Balance = etherBalance, TokenName = "ETH" };
        }

        public async Task<BalanceResult> GetTokenBalancesAsync(string tokenName, string account ,string chainId)
        {
            var web3 = GetWeb3(chainId);
            var token = TokenListService.GetTokens().FirstOrDefault(t => t.Name == tokenName);

            var balanceOfMessage = new BalanceOfFunction() { Owner = account };
            var iniputOutput = new MulticallInputOutput<BalanceOfFunction, BalanceOfOutputDTO>(balanceOfMessage, token.Address);
            
            await web3.Eth.GetMultiQueryHandler().MultiCallAsync(iniputOutput).ConfigureAwait(false);
            var balance = iniputOutput.Output.Balance;

            if (balance > 0)
            {
                var balanceResult = new BalanceResult()
                {
                    Balance = Web3.Convert.FromWei(balance, token.Decimals),
                    TokenImage = token.LogoURI,
                    TokenName = token.Symbol,
                    TokenAdress = token.Address
                };

                return balanceResult;
            }

            return null;
        }

        private Web3 GetWeb3(string chianId)
        {
            var url = string.Empty;

            if(chianId.EndsWith("1"))
            {
                url = "https://eth.drpc.org";
            }
            else
            {
                url = "https://goerli.blockpi.network/v1/rpc/public";
            }
        
            return new Web3(url);
        }
    }
}
