using Functionland.FxBlox.Shared.Dtos.Authentication;

namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IAuthenticationService
{
    Task SignIn(UserDto user);

    Task SignOut();

}
