using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Sign.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public partial class JavaScriptWalletService : IWalletService
    {
        private readonly IJSRuntime _js;
        public JavaScriptWalletService(IJSRuntime jsRuntime)
        {
            _js = jsRuntime;
        }

        public async Task<SessionStruct> ConnectAsync(EthereumChain ethereumChain, CancellationToken cancellationToken = default)
        {
            var sessionStruct = await _js.InvokeAsync<string>("WalletConnect.ConnectToWallet", ((int)ethereumChain).ToString());
            Preferences.Set("sessionTopic", sessionStruct);
            return new SessionStruct();
        }

        public void OpenConnectWallet(string url)
        {
            throw new NotImplementedException();
        }

        public async Task TransferSomeMoneyAsync()
        {
            var session = Preferences.Get("sessionTopic", string.Empty);
        }
    }
}
