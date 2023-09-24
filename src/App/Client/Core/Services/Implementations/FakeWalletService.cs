﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WalletConnectSharp.Core;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign.Models.Engine;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public class FakeWalletService : IWalletService
    {
        public async Task<SessionStruct> ConnectAsync(BlockchainNetwork ethereumChain, CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            return new SessionStruct();
        }

        public virtual void OpenConnectWallet(string url)
        {

        }

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
