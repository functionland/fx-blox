using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Core;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign.Models.Engine;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public abstract class WalletService : IWalletService
    {
        public async Task<SessionStruct> ConnectAsync(BlockchainNetwork ethereumChain, CancellationToken cancellationToken = default)
        {
            var dappOptions = new SignClientOptions()
            {
                ProjectId = "94a4ca39db88ee0be8f6df95fdfb560a",
                Metadata = new Metadata()
                {
                    Description = "Functionland Blox Description ....",
                    Icons = new[] { "https://fx.land/blox-icon.png" },
                    Name = "Functionland Blox",
                    Url = "https://fx.land/"
                },
                // Uncomment to disable persistant storage
                // Storage = new InMemoryStorage()
            };

            var dappConnectOptions = new ConnectOptions()
            {
                RequiredNamespaces = new RequiredNamespaces()
                {
                    {
                        "eip155", new ProposedNamespace
                        {
                            Methods = new[]
                            {
                                "eth_sendTransaction",
                                "eth_signTransaction",
                                "eth_sign",
                                "personal_sign",
                                "eth_signTypedData",
                            },
                            Chains = new[]
                            {
                                "eip155:1"
                            },
                            Events = new[]
                            {
                                "chainChanged",
                                "accountsChanged",
                            }
                        }
                    }
                }
            };

            var dappClient = await WalletConnectSignClient.Init(dappOptions);
            var connectData = await dappClient.Connect(dappConnectOptions);
            OpenConnectWallet(connectData.Uri);
            var session = await connectData.Approval;
            return session;
        }

        public abstract void OpenConnectWallet(string url);

        public async Task<string> SignMessage(string message)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return message;
        }

        public async Task<string> TransferSomeMoneyAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return "0x9f4261b706ff88567033fc2191be20fccdd555f442d2ca3016e9120b0d80971a";
        }
    }
}
