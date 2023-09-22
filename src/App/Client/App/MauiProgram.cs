using System.Reflection;

using Functionland.FxBlox.Client.Core;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Shared.Services.Contracts;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.FileProviders;
using Microsoft.Maui.Controls;

namespace Functionland.FxBlox.Client.App
{
    public static class MauiProgram
    {
        public static MauiAppBuilder CreateMauiAppBuilder()
        {
            AppCenter.Start("50ca1258-51c7-4d39-9e6a-fa3a417d774b",
                     typeof(Analytics), typeof(Crashes));
#if !BlazorHybrid
            throw new InvalidOperationException("Please switch to blazor hybrid as described in readme.md");
#endif

            var builder = MauiApp.CreateBuilder();
            var assembly = typeof(MainLayout).GetTypeInfo().Assembly;

            builder
                .UseMauiApp<App>()
                .Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);

            var services = builder.Services;

            services.AddMauiBlazorWebView();
#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

            services.AddScoped(sp =>
            {
                HttpClient httpClient = new(sp.GetRequiredService<AppHttpClientHandler>())
                {
                    BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>().GetApiServerAddress())
                };

                return httpClient;
            });

            services.AddTransient<IAuthTokenProvider, ClientSideAuthTokenProvider>();
            services.AddSharedServices();
            services.AddClientSharedServices();
            services.AddClientAppServices();

            return builder;
        }
    }
}