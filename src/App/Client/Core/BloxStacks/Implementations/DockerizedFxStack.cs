using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Implementations;

public abstract partial class DockerizedFxStack : IFxStack
{
    [AutoInject] private IBloxDockerManager BloxDockerManager { get; set; } = default!;

    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract Task NavigateToConfigurationPageAsync();
    public abstract Task<BloxStackStatusReport> GetStatusReportAsync(BloxDevice bloxDevice,
        CancellationToken cancellationToken);

    public async Task DeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken)
    {
        await OnDeployAsync(bloxDevice, cancellationToken);
    }

    protected virtual async Task OnDeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken)
    {
        var dockerImage = GetDockerImageName();
        await BloxDockerManager.DeployAsync(bloxDevice, dockerImage, cancellationToken);
    }

    public abstract string GetDockerImageName();

}