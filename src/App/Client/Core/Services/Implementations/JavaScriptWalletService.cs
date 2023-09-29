using Functionland.FxBlox.Client.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletConnectSharp.Sign.Controllers;
using WalletConnectSharp.Sign.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public partial class JavaScriptWalletService : IJavaScriptWalletService
    {
        private const string SessionStruct = "sessionStruct";
        private readonly IJSRuntime _js;
        public JavaScriptWalletService(IJSRuntime jsRuntime)
        {
            _js = jsRuntime;
        }

        public async Task<SessionStruct> ConnectAsync(BlockchainNetwork ethereumChain, CancellationToken cancellationToken = default)
        {
            var sessionStruct = await _js.InvokeAsync<string>("WalletConnect.ConnectToWallet", ((int)ethereumChain).ToString());
            Preferences.Set(SessionStruct, sessionStruct);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(sessionStruct);
        }

        public void OpenConnectWallet(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TransferSomeMoneyAsync()
        {
            try
            {
                var session = Preferences.Get(SessionStruct, string.Empty);
                var sessionStruct = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(session);
                var topic = sessionStruct.Topic;

                var currentWallet = GetCurrentAddress();
                var toWalletId = "0xafCC2bA0aD8B6DEEADA52EdE1467798A36BF27Bb";
                var amount = ((long)(0.0001 * Math.Pow(10, 18))).ToString("X");
                var hexAmount = $"0x{amount}";
                var transaction = await _js.InvokeAsync<string>("WalletConnect.TransferMoney", topic, currentWallet.Address, toWalletId, currentWallet.ChainId, hexAmount);
                return transaction;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public async Task<string> SignMessage(string message)
        {
            try
            {
                var session = Preferences.Get(SessionStruct, string.Empty);
                var sessionStruct = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(session);
                var topic = sessionStruct.Topic;
                var currentWallet = GetCurrentAddress();

                var transaction = await _js.InvokeAsync<string>("WalletConnect.SignMessage", message, currentWallet.Address, topic, currentWallet.ChainId);

                return transaction;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public Caip25Address GetCurrentAddress()
        {
            try
            {
                var chain = "eip155";
                var session = Preferences.Get(SessionStruct, string.Empty);
                var sessionStruct = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(session);

                var defaultNamespace = sessionStruct.Namespaces[chain];

                if (defaultNamespace.Accounts.Length == 0)
                    return null;

                var fullAddress = defaultNamespace.Accounts[0];
                var addressParts = fullAddress.Split(":");

                var address = addressParts[2];
                var chainId = string.Join(':', addressParts.Take(2));

                return new Caip25Address()
                {
                    Address = address,
                    ChainId = chainId,
                };
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
