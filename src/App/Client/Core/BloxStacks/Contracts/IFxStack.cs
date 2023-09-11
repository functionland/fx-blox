using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Contracts
{
    public interface IFxStack
    {
        string Title { get; }
        string Description { get; }
        Task NavigateToConfigurationPageAsync();
        Task<BloxStackStatusReport> GetStatusReportAsync(BloxDevice bloxDevice, CancellationToken cancellationToken);
        Task ConfigureBloxAsync(BloxDevice bloxDevice, CancellationToken cancellationToken);
    }
}
