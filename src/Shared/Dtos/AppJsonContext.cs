using Functionland.FxBlox.Shared.Dtos.Authentication;

namespace Functionland.FxBlox.Shared.Dtos;

/// <summary>
/// https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
/// </summary>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
//[JsonSerializable(typeof(List<UserDto>))]
[JsonSerializable(typeof(RestErrorInfo))]
[JsonSerializable(typeof(SignInResponseDto))]
public partial class AppJsonContext : JsonSerializerContext
{
}
