using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public partial class BloxConnectionService : IBloxConnectionService
    {
        [AutoInject]
        BloxConnectionFactory BloxConnectionFactory { get; set; }
        
        private List<BloxConnection> ConnectionsCache { get; set; } = new();

        public bool IsInitialized { get; set; } = false;

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                // ToDo Load information from local storage.
            }
            finally
            {
                IsInitialized = true;
            }
        }

        public void ThrowIfNotInitialized()
        {
            if (!IsInitialized)
                throw new InvalidOperationException("BloxConnectionService has not been initialized yet.");
        }

        public List<BloxConnection> GetConnections(CancellationToken cancellationToken)
        {
            ThrowIfNotInitialized();
            return ConnectionsCache.ToList();
        }

        public BloxConnection CreateNew(BloxDevice device, CancellationToken cancellationToken)
        {
            ThrowIfNotInitialized();
            var connection = BloxConnectionFactory.Create(device);
            ConnectionsCache.Add(connection);
            return connection;
        }

        public void RemoveConnection(BloxConnection connection, CancellationToken cancellationToken)
        {
            ThrowIfNotInitialized();
            ConnectionsCache.Remove(connection);
        }
    }
}
