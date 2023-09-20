using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Storage.Interfaces;
using System.Text.Json;

namespace Functionland.FxBlox.Client.Core.Services.Implementations
{
    public class WalletStorageService : IKeyValueStorage, IDisposable
    {
        protected Dictionary<string, object> Entries = new Dictionary<string, object>();

        public async Task Clear()
        {
            Preferences.Clear();
        }

        public void Dispose()
        {
           
        }

        public async Task<object[]> GetEntries()
        {
            throw new NotImplementedException();
        }

        public async Task<T[]> GetEntriesOfType<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetItem<T>(string key)
        {
            if (!typeof(T).IsValueType)
            {
                var rawReult = Preferences.Get(key, null);
                if (rawReult is null) return default;
                return JsonSerializer.Deserialize<T>(rawReult);
            }

            T typeDefaultValue = default!;
      
            switch (typeDefaultValue)
            {
                case int defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                case long defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                case DateTime defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                case double defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                case string defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                case float defaultValue:
                    return (T)(object)Preferences.Get(key, defaultValue);
                default: throw new NotImplementedException();

            };
        }

        public Task<string[]> GetKeys()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasItem(string key)
        {
            return Preferences.ContainsKey(key);
        }

        public async Task Init()
        {
        }

        public async Task RemoveItem(string key)
        {
            Preferences.Remove(key);
        }

        public async Task SetItem<T>(string key, T value)
        {

            if (!typeof(T).IsValueType)
            {
                Preferences.Set(key, JsonSerializer.Serialize<T>(value));
            }

            T typeDefaultValue = default!;

            switch (typeDefaultValue)
            {
                case int defaultValue:
                   Preferences.Set(key, defaultValue);
                    break;
                case long defaultValue:
                    Preferences.Set(key, defaultValue);
                    break;
                case DateTime defaultValue:
                        Preferences.Set(key, defaultValue);
                    break;
                case double defaultValue:
                        Preferences.Set(key, defaultValue);
                    break;
                case string defaultValue:
                   Preferences.Set(key, defaultValue);
                    break;
                case float defaultValue:
                    Preferences.Set(key, defaultValue);
                    break;
                default: throw new NotImplementedException();

            };
        }
    }
}
