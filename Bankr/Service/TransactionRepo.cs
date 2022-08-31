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
	public class TransactionRepository
    {
        string _dbPath;

        private SQLiteConnection conn;


        private void Init()
        {

            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Transaction>();
        }


        public TransactionRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Transaction> GetTransactionsAsync()
        {
            try
            {
                Init(); //first connect

                return conn.Table<Transaction>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Transaction>();
        }

        public Transaction GetTransactionFromId(int id)
        {
            try
            {
                Init();
                return conn.Table<Transaction>().Where(i => i.TransactionId == id).Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        

        public void MakeTransactionAsync(Transaction item)
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

        //todo: GetSenderId

        //todo: GetReceiverId
    }
}

