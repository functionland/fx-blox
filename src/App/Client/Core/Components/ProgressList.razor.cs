

using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Components;

public partial class ProgressList
{
    [Parameter]
    public List<ProgressItem> ProgressItems { get; set; } = new List<ProgressItem>();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }
    
}
