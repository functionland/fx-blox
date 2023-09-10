using Functionland.FxBlox.Shared.Dtos.Authentication;
using Microsoft.JSInterop;

namespace Functionland.FxBlox.Client.Core.Services.Implementations;

public partial class AuthenticationService : IAuthenticationService
{
    [AutoInject] private HttpClient _httpClient = default!;

    [AutoInject] private IJSRuntime _jsRuntime = default!;

    [AutoInject] private AppAuthenticationStateProvider _authenticationStateProvider = default!;

    public async Task SignIn(UserDto user)
    {
        user.UserAgent = await _jsRuntime.InvokeAsync<string>("eval", "window.navigator.userAgent");
        var tokenResponse = await (await _httpClient.PostAsJsonAsync("Auth/SignIn", user)).Content.ReadFromJsonAsync<SignInResponseDto>();

        if (tokenResponse?.AccessToken is null)
            return;

#if BlazorHybrid
        Preferences.Set("access_token", tokenResponse!.AccessToken);
#else
        await _jsRuntime.InvokeVoidAsync("App.setCookie", "access_token", tokenResponse.AccessToken);
#endif

        await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
    }

    public async Task SignOut()
    {
#if BlazorHybrid
        Preferences.Remove("access_token");
#else
        await _jsRuntime.InvokeVoidAsync("App.removeCookie", "access_token");
#endif

        await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
    }
}
