using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Functionland.FxBlox.Client.Core.Components;
public partial class PasswordModal
{
    private FxToast _fxToast = default!;
    [Parameter] public bool IsOpen { get; set; }
    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
    [Parameter] public EventCallback<string> OnSubmit { get; set; }
    [Parameter] public string WifiName { get; set; } = string.Empty;

    private string Password { get; set; } = string.Empty;

    private async Task OnSubmitPasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            await _fxToast.HandleShow("Empty password", "Password can't be empty!", FxToastType.Error);
            return;
        }
        IsOpen = false;
        await OnSubmit.InvokeAsync(Password);
    }

    private async Task OnCancelAsync()
    {
        IsOpen = false;
        Password = string.Empty;
        await IsOpenChanged.InvokeAsync(false);
    }
}
