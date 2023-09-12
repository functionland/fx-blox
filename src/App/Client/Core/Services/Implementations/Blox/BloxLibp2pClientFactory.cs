using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;
using Functionland.FxBlox.Client.Core.Services.Contracts;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    /// <summary>
    /// Use this factory to initialize proper Libp2p client for your Blox device
    /// </summary>
    public partial class BloxLibp2pClientFactory
    {
        [AutoInject]
        IServiceProvider ServiceProvider {get; set; }
        public IBloxLibp2pClient Create(BloxDevice device)
        {
            var client = ServiceProvider.GetRequiredService<IBloxLibp2pClient>();
            client.Initialize(device);
            return client;
        }
    }
}
