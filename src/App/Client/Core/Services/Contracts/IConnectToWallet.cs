using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IConnectToWallet
    {
        void Connect(string url);
    }
}
