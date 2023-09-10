namespace Functionland.FxBlox.Shared.Dtos.Authentication;

[DtoResourceType(typeof(AppStrings))]
public class SignInRequestDto
{
    [Required(ErrorMessage = nameof(AppStrings.RequiredAttribute_ValidationError))]
    [EmailAddress(ErrorMessage = nameof(AppStrings.EmailAddressAttribute_ValidationError))]
    [Display(Name = nameof(AppStrings.Email))]
    public string? UserName { get; set; }
}
