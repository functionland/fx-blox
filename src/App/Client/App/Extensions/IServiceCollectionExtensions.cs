using Functionland.FxBlox.Client.App;
using Functionland.FxBlox.Client.App.Services;
using Functionland.FxBlox.Client.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddClientAppServices(this IServiceCollection services)
        {
            // Services being registered here can get injected in Android, iOS, Windows, and Mac.

            string connectionString = $"DataSource={Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "FxDB.db")};";
            services.AddSingleton<IFxLocalDbService, FxLocalDbService>(_ => new FxLocalDbService(connectionString));

#if ANDROID
            services.AddClientAndroidServices();
#elif iOS
        services.AddClientiOSServices();
#elif Mac
        services.AddClientMacServices();
#elif Windows
        services.AddClientWindowsServices();
#endif

            services.AddTransient<MainPage>();
            services.AddSingleton<IBitDeviceCoordinator, AppDeviceCoordinator>();

            return services;
        }
    }
}