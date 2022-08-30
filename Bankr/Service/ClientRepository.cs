using Bankr.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankr.Service
{
    public class ClientRepository
    {
        string _dbPath;

        private SQLiteConnection conn;


        private void Init()
        {

            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Client>();
        }


        public ClientRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Client> GetClientsAsync()
        {
            try
            {
                Init(); //first connect

                return conn.Table<Client>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Client>();
        }

        public Client GetClientFromIdAsync(int id)
        {
            return conn.Table<Client>().Where(i => i.Id == id).Single();
        }
        //public Task<List<People>> GetCustomers()
        //{
        //  return Database.QueryAsync<People>("SELECT * FROM [people] WHERE [Role]=Customer");
        //}

        // public Task<People> GetPeopleAsync(int id)
        //{
        //  return Database.Table<People>().Where(i => i.Id == id).FirstOrDefaultAsync();
        //}

        public void SaveClientAsync(Client item)
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
        public void DeleteClient(int id)
        {
            Debug.WriteLine("DB Id: " + id.ToString());

            try
            {
                conn.Delete<Client>(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

