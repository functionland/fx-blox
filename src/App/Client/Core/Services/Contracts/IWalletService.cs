using Functionland.FxBlox.Client.Core.Models;
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
        Task<SessionStruct> ConnectAsync(BlockchainNetwork ethereumChain, CancellationToken cancellationToken = new());
        void OpenConnectWallet(string url);

        Task<string> TransferSomeMoneyAsync();

        Task<string> SignMessage(string message);
        Caip25Address GetCurrentAddress(SessionStruct currentSession, string chain);
    }
}
