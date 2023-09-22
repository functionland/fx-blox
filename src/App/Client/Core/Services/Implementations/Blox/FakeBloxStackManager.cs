using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public class BloxStackManager : IBloxStackManager
    {
        public async Task DeployStackAsync(BloxStack bloxStack, CancellationToken cancellationToken = default)
        {
            await bloxStack.Stack.DeployAsync(bloxStack.Device, cancellationToken);
        }
    }
}
