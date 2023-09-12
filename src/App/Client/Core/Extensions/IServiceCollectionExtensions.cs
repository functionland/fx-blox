using Functionland.FxBlox.Client.Core.Services.Contracts;
using Functionland.FxBlox.Client.Core.Services.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddClientSharedServices(this IServiceCollection services)
        {
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

            services.AddSingleton<BloxWifiHotspotClientFactory>();
            services.AddTransient<IBloxWifiHotspotClient, FakeBloxWifiHotspotClient>();

            services.AddSingleton<BloxConnectionFactory>();

            return services;
        }

        public static async Task RunAppEvents(this IServiceProvider serviceProvider)
        {
            var exceptionHandler = serviceProvider.GetRequiredService<IExceptionHandler>();
            try
            {
                var FxLocalDbService = serviceProvider.GetRequiredService<IFxLocalDbService>();
                await FxLocalDbService.InitAsync();
            }
            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
            }
        }
    }
}