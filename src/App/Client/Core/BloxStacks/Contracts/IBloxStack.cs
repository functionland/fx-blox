using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Contracts
{
    public interface IBloxStack
    {
        string Title { get; }
        string Description { get; }
        Task NavigateToConfigurationPageAsync();
        Task<BloxStackStatusReport> GetStatusReportAsync();
        Task ConfigureBloxAsync(BloxDevice bloxDevice);
    }
}
