using Microsoft.AspNetCore.Components.Web;

namespace Functionland.FxBlox.Client.Core.Components;

public partial class FxBackButton
{
    [Parameter]
    public bool IsEnabled { get; set; } = true;

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter]
    public string? Class { get; set; }
}