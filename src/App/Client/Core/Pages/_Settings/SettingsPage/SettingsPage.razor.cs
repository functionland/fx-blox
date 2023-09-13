namespace Functionland.FxBlox.Client.Core.Pages;

public partial class SettingsPage
{
    private bool _applyAnimation = false;
   
    private string? CurrentTheme { get; set; }
    private string? CurrentVersion { get; set; }

    private int _counter = 0;
    private const int MaxCount = 7;

    protected override async Task OnInitAsync()
    {
       
        GoBackService.SetState(Task ()=>
        {
             UpdateBackButtonDeviceBehavior();
             return Task.CompletedTask;
        }, true, false);

        GetAppVersion();
    }

    private void UpdateBackButtonDeviceBehavior()
    {
        NavigationManager.NavigateTo("mydevice", false, true);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _applyAnimation = true;
            StateHasChanged();
        }
    }


    public void HandleTitleClick()
    {
        if (_counter >= MaxCount && AppStateStore.IsAvailableForTest) return;

        _counter++;

        if (_counter >= MaxCount)
        {
            AppStateStore.IsAvailableForTest = true;
        }
    }

    private void GetAppVersion()
    {
#if BlazorHybrid
        CurrentVersion = AppInfo.Current.VersionString;
#endif
    }
}