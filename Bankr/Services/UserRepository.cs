using System;
using System.Diagnostics;
using Bankr.Model;
using SQLite;

namespace Bankr.Services
{
	public class UserRepository
	{
        string _dbPath; // this property -> our db file

        private SQLiteConnection conn;

        // initialises db connection each time

        private void Init()
        {
            //Connect to db

            if (conn != null) // of alreay connected, don't again
                return;

            // Connecting to db file
            conn = new SQLiteConnection(_dbPath);
            // Create table if not already existing
            conn.CreateTable<User>();


        }

        // Constructor to set our properties

        public UserRepository(string dbPath)
        {
            _dbPath = dbPath;

        }


        // CREATE: a new user
        public void CreateNewUser(User person)
        {
            try
            {
                Init(); // first connect to file
                conn.Insert(person); // Insert new user to row
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // READ: Get all the users from db
        public List<User> GetAllUsers()
        {
            try
            {
                Init();// first connect to file
                return conn.Table<User>().ToList();//get all users

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<User>();
        }


        // DELETE: REmove user from db

        public void DeleteUser(int id)
        {
            try
            {

                conn.Delete(id);

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

