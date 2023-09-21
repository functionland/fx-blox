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
                // ToDo: Load information from local storage.
            }
            finally
            {
                IsInitialized = true;
            }
        }

        public async Task SaveToStorageAsync()
        {
            // ToDo: Save information to local storage
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

        public async Task<BloxConnection> CreateForDeviceAsync(BloxDevice device, CancellationToken cancellationToken = default)
        {
            ThrowIfNotInitialized();
            var connection = BloxConnectionFactory.Create(device);
            ConnectionsCache.Add(connection);
            await SaveToStorageAsync();
            return connection;
        }

        public async Task LoadDeviceInfoAsync(BloxConnection connection, CancellationToken cancellationToken = default)
        {
            var bloxInfo = await connection.GetDeviceInfoAsync(cancellationToken);
            connection.Device.HardwareId = bloxInfo.HardwareId;
            await SaveToStorageAsync();
        }

        public async Task RemoveConnectionAsync(BloxConnection connection, CancellationToken cancellationToken)
        {
            ThrowIfNotInitialized();
            ConnectionsCache.Remove(connection);
            await SaveToStorageAsync();
        }
    }
}
