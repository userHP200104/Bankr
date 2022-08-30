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
    public class StaffRepository
    {
        string _dbPath;

        private SQLiteConnection conn;


        private void Init()
        {

            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Staff>();
        }


        public StaffRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Staff> GetStaff()
        {
            try
            {
                Init(); //first connect

                return conn.Table<Staff>().ToList(); 
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Staff>();
            
        }

        public Staff GetStaffFromId(int id)
        {
            return conn.Table<Staff>().Where(i => i.Id == id).Single();
        }
        //public Task<List<People>> GetCustomers()
        //{
        //  return Database.QueryAsync<People>("SELECT * FROM [people] WHERE [Role]=Customer");
        //}

        // public Task<People> GetPeopleAsync(int id)
        //{
        //  return Database.Table<People>().Where(i => i.Id == id).FirstOrDefaultAsync();
        //}

        public void SaveStaff(Staff item)
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
        public void DeleteStaff(int id)
        {
            Debug.WriteLine("DB Id: " + id.ToString());

            try
            {
                conn.Delete<Staff>(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

