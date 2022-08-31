using Bankr.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Content.ClipData;

namespace Bankr.Service
{
    public class AccountRepository
    {
        string _dbPath;

        private SQLiteConnection conn;


        private void Init()
        {

            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Account>();
        }


        public AccountRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Account> GetAccountsAsync()
        {
            try
            {
                Init(); //first connect

                return conn.Table<Account>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Account>();
        }

        public Account GetAccountFromId(int id)
        {
            try
            {
                Init();
                return conn.Table<Account>().Where(i => i.Id == id).Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Account> GetAccountsForClient(int clientid)
        {
            try
            {
                Init();
                return conn.Table<Account>().Where(i => i.ClientId == clientid).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //public Task<List<People>> GetCustomers()
        //{
        //  return Database.QueryAsync<People>("SELECT * FROM [people] WHERE [Role]=Customer");
        //}

        // public Task<People> GetPeopleAsync(int id)
        //{
        //  return Database.Table<People>().Where(i => i.Id == id).FirstOrDefaultAsync();
        //}

        public void AddAccount(Account item)
        {
            try
            {
                Init();
                int v = conn.Insert(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void DeleteAccount(int id)
        {
            Debug.WriteLine("DB Id: " + id.ToString());

            try
            {
                conn.Delete<Account>(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool UpdateAccount(int id, string name, string surname)
        {
            try
            {
                Init();

                var client = conn.Table<Client>().Where(x => x.Id == id).FirstOrDefault();

                if (client != null)
                {
                    if (name != null)
                    {
                        client.Name = name;
                    }
                    if (surname != null)
                    {
                        client.Surname = surname;
                    }
                    var i = conn.Update(client);

                    if (i == -1)
                    {
                        Debug.WriteLine("Issue updating");
                    }
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
    }
}

