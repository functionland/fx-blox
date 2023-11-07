using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Implementations
{
    public class FakeRocketPoolStack : IFxStack
    {
        public string Title => "SSN Stack";
        public string Description => "SSN Stack Description";
        public Task NavigateToConfigurationPageAsync()
        {
            return Task.CompletedTask;
        }

        private BloxStackStatusReport FakeStatusReport { get; set; } = new(BloxStackStatus.None, "Not initialized yet");

        public void SetStatusReport(BloxStackStatusReport statusReport)
        {
            FakeStatusReport = statusReport;
        }

        public Task<BloxStackStatusReport> GetStatusReportAsync(BloxDevice bloxDevice,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(FakeStatusReport);
        }

        public async Task DeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
    }
}
