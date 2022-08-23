using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankr.Model;

namespace Bankr.Data
{
    public class BankrDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BankrDatabase> Instance =
            new AsyncLazy<BankrDatabase>(async () =>
            {
                var instance = new BankrDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<People>();
                    CreateTableResult resultAccounts = await Database.CreateTableAsync<Account>();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return instance;
            });

        public BankrDatabase()
        {
            Database= new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<People>> GetStaffAsync()
        {
            return Database.QueryAsync<People>("SELECT * FROM [people] WHERE NOT [Role]='Customer'");
        }

        public Task<List<People>> GetCustomersAsync()
        {
            return Database.QueryAsync<People>("SELECT * FROM [people] WHERE [Role]='Customer'");
        }

         public Task<People> GetPeopleFromIdAsync(int id)
        {
          return Database.Table<People>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        //public Task<List<People>> GetCustomers()
        //{
        //  return Database.QueryAsync<People>("SELECT * FROM [people] WHERE [Role]=Customer");
        //}

        // public Task<People> GetPeopleAsync(int id)
        //{
        //  return Database.Table<People>().Where(i => i.Id == id).FirstOrDefaultAsync();
        //}

        public Task<int> SavePeopleAsync(People item)
        {

                return Database.InsertAsync(item);
            
        }
        public Task<int> DeletePeopleAsync(People item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<List<Account>> GetAccountsAsync(string client_id)
        {
            return Database.QueryAsync<Account>("SELECT * FROM [account] WHERE [ClientId]='"+client_id+"'");
        }
        public Task<int> SaveAccountAsync(Account item)
        {

            return Database.InsertAsync(item);

        }
    }
}
