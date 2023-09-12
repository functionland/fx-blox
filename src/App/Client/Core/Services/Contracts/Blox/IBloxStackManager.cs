using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Contracts
{
    public interface IBloxStackManager
    {
        Task<BloxStack> GetInstalledStacksAsync(BloxDevice device);
    }
}
