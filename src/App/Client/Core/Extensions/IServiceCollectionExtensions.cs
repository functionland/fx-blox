using Functionland.FxBlox.Client.Core.Services.Contracts;
using Functionland.FxBlox.Client.Core.Services.Implementations;

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
            }
            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
            }
        }
    }
}