using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;
using Functionland.FxBlox.Client.Core.Services.Implementations;
using Functionland.FxBlox.Client.Core.Tests.Extensions;
using Functionland.FxBlox.Client.Core.Tests.Implementations;
using Microsoft.Extensions.Hosting;

namespace Functionland.FxBlox.Client.Core.Tests
{
    public class WalletServiceTests
    {
        [Fact]
        public async Task WalletService_TransferSomeMoney_MustWork()
        {
            var testHost = Host.CreateDefaultBuilder()
                               .ConfigureServices((_, services) =>
                                   {
                                       services.AddClientSharedServices();
                                       services.AddClientTestServices();
                                       services.AddSingleton<IWalletService>(new WindowsWalletService());
                                   }
                               ).Build();

            var serviceScope = testHost.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var walletService = serviceProvider.GetRequiredService<IWalletService>();

            await walletService.TransferSomeMoneyAsync();

            //Assert.NotNull(connection.Device);
        }
    }
}