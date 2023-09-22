import { WalletConnectModalSign } from "@walletconnect/modal-sign-html";

export async function ConnectToWallet(ethereumChain) {
    try {
       
        const projectId = "94a4ca39db88ee0be8f6df95fdfb560a";

        const web3Modal = new WalletConnectModalSign({
            projectId,
            metadata: {
                name: "Functionland Blox",
                description: "Functionland Blox Description ....",
                url: "https://fx.land/",
                icons: ["https://fx.land/blox-icon.png"],
            },
        });

        const session = await web3Modal.connect({
            requiredNamespaces: {
                eip155: {
                    methods: ["eth_sendTransaction", "eth_signTransaction", "eth_sign", "personal_sign", "eth_signTypedData"],
                    chains: [`eip155:${ethereumChain}`],
                    events: ["chainChanged", "accountsChanged", "connect", "disconnect", "message"],
                },
            },
        });

     
        return session.toString();
    } catch (err) {
        console.error(err);
    }
}
