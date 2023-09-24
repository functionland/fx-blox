import { WalletConnectModalSign } from "@walletconnect/modal-sign-html";

export async function ConnectToWallet(ethereumChain) {

    clearWalletConnectCache();

    const web3Modal = new WalletConnectModalSign({
        projectId: "94a4ca39db88ee0be8f6df95fdfb560a",
        metadata: {
            name: "Functionland Blox",
            description: "Functionland Blox Description ....",
            url: "https://fx.land/",
            icons: ["https://fx.land/blox-icon.png"],
        },
    });

    var connectArgument = {
        requiredNamespaces: {
            eip155: {
                methods: ["eth_sendTransaction", "eth_signTransaction", "eth_sign", "personal_sign", "eth_signTypedData"],
                chains: [`eip155:${ethereumChain}`],
                events: ["chainChanged", "accountsChanged", "connect", "disconnect", "message"],
            },
        },
    };

    const session = await web3Modal.connect(connectArgument);

    return JSON.stringify(session);

}

export async function TransferMoney(topic, fromwalletid, towalletid, chainId, amount) {

    const web3Modal = new WalletConnectModalSign({
        projectId: "94a4ca39db88ee0be8f6df95fdfb560a",
        metadata: {
            name: "Functionland Blox",
            description: "Functionland Blox Description ....",
            url: "https://fx.land/",
            icons: ["https://fx.land/blox-icon.png"],
        },
    });

    var existsession = null;

    try {
        existsession = await web3Modal.getSession();
        if (existsession && existsession.topic) {
            topic = existsession.topic;
        }
    }
    catch (err) {

    }

    const transaction = {
        from: fromwalletid,
        to: towalletid,
        data: "0x",
        gasPrice: "0x029104e28c",
        gasLimit: "0x5208",
        value: amount,
    };

    var requestModel = {
        topic: topic,
        chainId: chainId,
        request: {
            method: "eth_sendTransaction",
            params: [transaction],
        },
    };

    const result = await web3Modal.request(requestModel);

    return result;
}


export async function SignMessage(message, address, topic, chainId) {

    const web3Modal = new WalletConnectModalSign({
        projectId: "94a4ca39db88ee0be8f6df95fdfb560a",
        metadata: {
            name: "Functionland Blox",
            description: "Functionland Blox Description ....",
            url: "https://fx.land/",
            icons: ["https://fx.land/blox-icon.png"],
        },
    });

    var existsession = null;

    try {
        existsession = await web3Modal.getSession();
        if (existsession && existsession.topic) {
            topic = existsession.topic;
        }
    }
    catch (err) {

    }

    var requestModel = {
        topic: topic,
        chainId: chainId,
        request: {
            method: "personal_sign",
            params: [message, address]
        },
    };

    const result = await web3Modal.request(requestModel);

    return result;

}

function clearWalletConnectCache() {

    var index = 0;
    while (true) {
        var key = localStorage.key(index);
        if (!key) {
            break;
        }

        if (key.toLowerCase().startsWith("wc") || key.toLowerCase().startsWith("wallet")) {
            localStorage.removeItem(key);
        } else {
            index++;
        }
    }
}