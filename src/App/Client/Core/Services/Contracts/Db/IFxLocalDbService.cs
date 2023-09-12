using Microsoft.Data.Sqlite;

namespace Functionland.FxBlox.Client.Core.Services.Contracts;

public interface IFxLocalDbService
{
    SqliteConnection CreateConnection();
    Task InitAsync();
}