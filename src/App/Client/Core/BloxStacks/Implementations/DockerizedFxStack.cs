using Functionland.FxBlox.Client.Core.BloxStacks.Contracts;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Implementations;

public abstract partial class DockerizedFxStack : IFxStack
{
    [AutoInject] private IBloxDockerManager BloxDockerManager { get; set; } = default!;

    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract Task NavigateToConfigurationPageAsync();
    public abstract Task<BloxStackStatusReport> GetStatusReportAsync(BloxDevice bloxDevice);

    public async Task ConfigureBloxAsync(BloxDevice bloxDevice)
    {
        await OnConfigureBloxAsync(bloxDevice);
    }

    protected virtual async Task OnConfigureBloxAsync(BloxDevice bloxDevice)
    {
        var dockerImage = GetDockerImageName();
        await BloxDockerManager.DeployAsync(bloxDevice, dockerImage);
    }

    public abstract string GetDockerImageName();

}