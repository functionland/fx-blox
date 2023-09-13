namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IAppStateStore
{
    bool IsAvailableForTest { get; set; }

    string CurrentPagePath { get; set; }
}