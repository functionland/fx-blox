using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Sign.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IWalletService
    {
        Task<SessionStruct> ConnectAsync(EthereumChain ethereumChain, CancellationToken cancellationToken = new());
        void OpenConnectWallet(string url);

        Task TransferSomeMoneyAsync();
    }
}
