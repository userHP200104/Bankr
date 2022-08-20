using System;
using Bankr.Model;
using SQLite;

namespace Bankr.Services
{
	public class AccountRepository
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
            conn.CreateTable<Account>();


        }

        // Constructor to set ou rproperties

        public AccountRepository(string dbPath)
        {
            _dbPath = dbPath;

        }
    }
}

