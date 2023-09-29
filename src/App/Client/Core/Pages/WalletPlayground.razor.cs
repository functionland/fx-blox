using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Pages;

public partial class WalletPlayground
{
    [AutoInject] private IJavaScriptWalletService WalletService = default!;

    private bool SucessFullTransfer = false;
    private bool _applyAnimation = false;
    private string TransactionLink { get; set; } = default!;
    private FxToast _toastRef = default!;
    private async Task ConnectToWallet()
    {
        try
        {
            await WalletService.ConnectAsync(BlockchainNetwork.EthereumTestnet);
        }
        catch (Exception ex)
        {
            await _toastRef.HandleShow("Connect", ex.Message,
                    FxToastType.Error);
        }
      
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _applyAnimation = true;

            StateHasChanged();
        }
    }

    private async Task TransferMoney()
    {
        var transaction = await WalletService.TransferSomeMoneyAsync();
        if (!string.IsNullOrEmpty(transaction))
        {
            SucessFullTransfer = true;
            TransactionLink = GetTransferTransactionLink(transaction).ToString();
        }
        else
        {
            await _toastRef.HandleShow("Transfer", "Fail",
                     FxToastType.Error);
        }
    }

    private async Task TestSignMessage()
    {
        var sign = await WalletService.SignMessage("Sign this message");

        if (!string.IsNullOrWhiteSpace(sign))
        {
            await _toastRef.HandleShow( "Sign", "Successful",
                     FxToastType.Success);
        }
        else
        {
            await _toastRef.HandleShow("Sign", "Fail",
                     FxToastType.Error);
        }
    }

    private Uri GetTransferTransactionLink(string transaction)
    {
        var currentWallet = WalletService.GetCurrentAddress();

        var chainId = currentWallet.ChainId;
        Uri uri = null;

        if (chainId.EndsWith("1"))
        {
            uri = new Uri($"https://etherscan.io/tx/{transaction}");
        }
        else
        {
            uri = new Uri($"https://goerli.etherscan.io/tx/{transaction}");
        }

        return uri;

    }
}