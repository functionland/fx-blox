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