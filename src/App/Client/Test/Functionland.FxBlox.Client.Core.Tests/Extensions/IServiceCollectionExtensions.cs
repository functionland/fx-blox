using Functionland.FxBlox.Client.Core.Services.Contracts;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Client.Core.TestInfra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Tests.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddClientTestServices(this IServiceCollection services)
        {
            var testDir = Assembly.GetExecutingAssembly().Location;
            string connectionString = $"DataSource={Path.Combine(testDir, "FxDB.db")}";
            services.AddSingleton<IFxLocalDbService, FxLocalDbService>(_ => new FxLocalDbService(connectionString));

            services.AddTransient<IBloxHotspotClient, FakeBloxHotspotClient>();
            services.AddTransient<IBloxLibp2pClient, FakeBloxLibp2pClient>();

            //services.AddSingleton<IPlatformTestService, FakePlatformTestService>();

            //services.AddTransient<FakeFileServicePlatformTest_CreateTypical>();
            
            //var cacheDirectory = Path.Combine(testContext.TestDir, "TestCache");
            //Directory.CreateDirectory(cacheDirectory);

            return services;
        }
    }
}
