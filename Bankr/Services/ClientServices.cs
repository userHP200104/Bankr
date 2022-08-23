using System;
using SQLite;

namespace Bankr.Services
{
	public class Client : IClient
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Client.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Client>();
            }
        }

        public async Task<int> AddClient(Client client)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(client);
        }

        public async Task<int> DeleteClient(Client client)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(client);
        }

        public async Task<List<Client>> GetClientList()
        {
            await SetUpDb();
            var clientList = await _dbConnection.Table<Client>().ToListAsync();
            return clientList;
        }

        public async Task<int> UpdateClient(Client client)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(client);
        }
    }
}

