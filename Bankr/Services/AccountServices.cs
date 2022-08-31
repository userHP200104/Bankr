using System;
using SQLite;

namespace Bankr.Services
{
	public class Account : IAccount
	{
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Account.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Account>();
            }
        }

        public async Task<int> AddAccount(Account account)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(account);
        }

        public async Task<int> DeleteAccount(Account account)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(account);
        }

        public async Task<List<Account>> GetAccountList()
        {
            await SetUpDb();
            var accountList = await _dbConnection.Table<Account>().ToListAsync();
            return accountList;


        }

        public async Task<int> UpdateAccount(Account account)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(account);
        }
    }
}

