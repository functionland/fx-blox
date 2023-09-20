using WalletConnectSharp.Core;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign.Models.Engine;

namespace Functionland.FxBlox.Client.Core.Pages
{
    public partial class HomePage
    {
        //[AutoInject] private IConnectToWallet connectToWallet = default!;
        private async Task ConnectToWallet()
        {
            try
            {
                var testAddress = "0xd8dA6BF26964aF9D7eEd9e03E53415D37aA96045";
                testAddress = "0x1681BEb1267292C718Ed653A78fB42f3c239C52E";

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
                //connectToWallet.Connect(connectData.Uri);
                var app = await connectData.Approval;
            }
            catch (Exception exp)
            {
                ExceptionHandler.Handle(exp);
            }

        }
    }
}
