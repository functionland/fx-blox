using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Implementations;

public abstract partial class DockerizedFxStack : FxStack
{
    [AutoInject] private IBloxDockerManager BloxDockerManager { get; set; } = default!;

    protected override async Task OnDeployAsync(BloxDevice bloxDevice, CancellationToken cancellationToken)
    {
        var dockerImage = GetDockerImageName();
        var environmentVariables = GetEnvironmentVariables();
        await BloxDockerManager.DeployAsync(bloxDevice, dockerImage, environmentVariables, cancellationToken);
    }

    public abstract string GetDockerImageName();
    public abstract List<KeyValuePair<string, string>> GetEnvironmentVariables();

}