namespace Functionland.FxBlox.Client.Core.Services.Implementations;

public class InMemoryAppStateStore : IAppStateStore
{
    public bool IsAvailableForTest { get; set; } = true;
    public string CurrentPagePath { get; set; } = "/";
}