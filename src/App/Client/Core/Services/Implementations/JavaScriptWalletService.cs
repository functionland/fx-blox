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
        private readonly IJSRuntime _js;
        public JavaScriptWalletService(IJSRuntime jsRuntime)
        {
            _js = jsRuntime;
        }

        public async Task<SessionStruct> ConnectAsync(BlockchainNetwork ethereumChain, CancellationToken cancellationToken = default)
        {
            try
            {
                var sessionStruct = await _js.InvokeAsync<string>("WalletConnect.ConnectToWallet", ((int)ethereumChain).ToString());
                Preferences.Set("sessionStruct", sessionStruct);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(sessionStruct);
            }
            catch (Exception ex)
            {

            }

            return new SessionStruct();
        }

        public void OpenConnectWallet(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TransferSomeMoneyAsync()
        {
            try
            {
                var session = Preferences.Get("sessionStruct", string.Empty);
                var sessionStruct = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(session);
                var topic = sessionStruct.Topic;
                var currentWallet = GetCurrentAddress(sessionStruct, "eip155");
                var toWalletId = "0xafCC2bA0aD8B6DEEADA52EdE1467798A36BF27Bb";
                var amount = ((long)(0.01 * Math.Pow(10, 18))).ToString("X");
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
                var session = Preferences.Get("sessionStruct", string.Empty);
                var sessionStruct = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStruct>(session);
                var topic = sessionStruct.Topic;
                var currentWallet = GetCurrentAddress(sessionStruct, "eip155");

                var transaction = await _js.InvokeAsync<string>("WalletConnect.SignMessage", message, currentWallet.Address, topic, currentWallet.ChainId);

                return transaction;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public Caip25Address GetCurrentAddress(SessionStruct currentSession, string chain)
        {
            var defaultNamespace = currentSession.Namespaces[chain];

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
    }
}
