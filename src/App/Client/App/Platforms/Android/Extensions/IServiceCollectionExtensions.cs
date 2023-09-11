using Functionland.FxBlox.Client.App.Platforms.Android.Implementations.Test;
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IAndroidServiceCollectionExtensions
    {
        public static IServiceCollection AddClientAndroidServices(this IServiceCollection services)
        {
            // Services being registered here can get injected in Android.
            services.AddSingleton<IPlatformTestService, AndroidPlatformTestService>();
            return services;
        }
    }
}