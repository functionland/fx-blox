using Functionland.FxBlox.Client.App.Platforms.Windows.Implementations;
using Functionland.FxBlox.Client.App.Platforms.Windows.PlatformTests;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IWindowsServiceCollectionExtensions
    {
        public static IServiceCollection AddClientWindowsServices(this IServiceCollection services)
        {
            // Services being registered here can get injected in Windows.
            services.AddSingleton<IWalletService, WindowsWalletService>();
            services.AddTransient<IPlatformTest, WindowsWalletServiceTransferSomeMoneyPlatformTest>();
            return services;
        }
    }
}