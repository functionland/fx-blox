using Functionland.FxBlox.Client.Core.TestInfra.Contracts;
using Functionland.FxBlox.Client.Core.TestInfra.Implementations;

namespace  Functionland.FxBlox.Client.Core.Pages;

public partial class BloxAddPage
{
    private Task HandleBack()
    {
        NavigationManager.NavigateTo("settings", false, true);
        return Task.CompletedTask;
    }
}

