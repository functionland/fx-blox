using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Implementations
{
    /// <summary>
    /// Inherit this class to add support for a new type of stack.
    /// </summary>
    public abstract class FxStack : IFxStack
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract Task NavigateToConfigurationPageAsync();
        public abstract Task<BloxStackStatusReport> GetStatusReportAsync(BloxDevice bloxDevice, CancellationToken cancellationToken);
        
        public async Task DeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken)
        {
            await OnDeployAsync(bloxDevice, cancellationToken);
        }

        protected abstract Task OnDeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken);
    }
}
