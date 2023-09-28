using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Client.Core.Services.Implementations.Ethereum;
using Functionland.FxBlox.Client.Core.Services.Implementations.EthereumService;
using Nethereum.Web3;
using WalletConnectSharp.Storage.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddClientSharedServices(this IServiceCollection services)
        {
            services.AddLocalization();
            services.AddScoped<ThemeInterop>();
            services.AddSingleton<IAppStateStore, InMemoryAppStateStore>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IExceptionHandler, ExceptionHandler>();
            services.AddScoped<IPubSubService, PubSubService>();

            services.AddTransient<AppHttpClientHandler>();

            services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IGoBackService, GoBackService>();
            services.AddScoped(sp => (AppAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());

            services.AddSingleton<BloxLibp2pClientFactory>();
            services.AddTransient<IBloxLibp2pClient, FakeBloxLibp2pClient>();

            services.AddSingleton<BloxHotspotClientFactory>();
            services.AddTransient<IBloxHotspotClient, FakeBloxHotspotClient>();

            services.AddSingleton<BloxConnectionFactory>();
            services.AddSingleton<IBloxConnectionService, BloxConnectionService>();
            services.AddSingleton<IKeyValueStorage, WalletStorageService>();

            services.AddSingleton<IWifiService, FakeWifiService>();
            services.AddSingleton<IBloxStackManager, BloxStackManager>();

            //services.AddScoped<IWalletService, FakeWalletService>();
            services.AddScoped<IWalletService, JavaScriptWalletService>();
            services.AddScoped<IJavaScriptWalletService, JavaScriptWalletService>();

            services.AddSingleton<TokenListService>();
            //services.AddSingleton<IEthereumService, FakeEthereumService>();
            services.AddSingleton<IEthereumService, EthereumService>();

            return services;
        }

        public static async Task RunAppEvents(this IServiceProvider serviceProvider)
        {
            var exceptionHandler = serviceProvider.GetRequiredService<IExceptionHandler>();
            try
            {
                var localDbService = serviceProvider.GetRequiredService<IFxLocalDbService>();
                await localDbService.InitAsync();

                var bloxConnectionService = serviceProvider.GetRequiredService<IBloxConnectionService>();
                await bloxConnectionService.InitializeAsync();

                await bloxConnectionService.CreateForDeviceAsync(new BloxDevice()
                {
                    HardwareId = "a48b2b11c2f44fc3a103c7daa8bf4dd4a96d9e5d65a027404a269de29d50dbbf",
                    PeerId = "a48b2b11c2f44fc3a103c7daa8bf4dd4a96d9e5d65a027404a269de29d50dbbf",
                    HotspotInfo = new WifiInfo() { Ssid = "", Essid = "", Rssi = 0 }
                });
            }
            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
            }
        }
    }
}