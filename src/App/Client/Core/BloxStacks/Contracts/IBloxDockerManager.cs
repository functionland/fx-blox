using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.BloxStacks.Contracts;

public interface IBloxDockerManager
{
    Task DeployAsync(BloxDevice bloxDevice, string dockerImage);
}