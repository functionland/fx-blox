using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Client.Core.Tests.Extensions;
using Microsoft.Extensions.Hosting;

namespace Functionland.FxBlox.Client.Core.Tests
{
    public class BloxConnectionTests
    {
        [Fact]
        public async Task BloxConnection_SimpleFake_MustWork()
        {
            var testHost = Host.CreateDefaultBuilder()
                               .ConfigureServices((_, services) =>
                                   {
                                       services.AddClientSharedServices();
                                       services.AddClientTestServices();
                                       //services.AddSingleton<IFileService>(FakeFileServiceFactory.CreateSimpleFileListOnRoot());
                                   }
                               ).Build();

            var serviceScope = testHost.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var factory = serviceProvider.GetRequiredService<BloxConnectionFactory>();

            using var connection = factory.Create(new BloxDevice() { HotspotInfo = new WifiInfo() { Essid = "", Rssi = 1, Ssid = "" } });

            Assert.NotNull(connection.Device);

            var wifiList = await connection.GetWifiListAsync(new CancellationToken());
            Assert.True(wifiList.Any());

            //Assert.NotNull(connection.Device);
        }
    }
}