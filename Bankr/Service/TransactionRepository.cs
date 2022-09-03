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

        public List<Transaction> GetTransactionsAsync(int id)
        {
            try
            {
                Init(); //first connect

                return conn.Table<Transaction>().Where(i => i.AccountIn == id).ToList();

                Debug.WriteLine("gots them");
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("dont gots them");
            }

            return new List<Transaction>();
        }

        public double GetRollover()
        {
            Init();
            return conn.Table<Transaction>().Sum(r => r.TransactionAmount);
        }

        public double GetTransactionFee()
        {
                Init();
                return conn.Table<Transaction>().Count() * 30;
        }

        public double GetInterest()
        {
            Init();
            return Math.Round(conn.Table<Transaction>().Sum(r => r.TransactionAmount * 0.1), 3);
        }

        public double GetNetTotal()
        {

            double rollover = GetRollover();
            double transactionFee = GetTransactionFee();
            double interest = GetInterest();

            double netTotal = 0;

            netTotal = rollover + transactionFee - interest;

            return netTotal;

        }

        public void Withdrawal(Transaction item)
        {
            Account accountOut = App.AccountRepo.GetAccountFromId(item.AccountOut);
            try
            {
                Init();


                App.AccountRepo.MoneyOut(item.AccountOut, item.TransactionAmount);
                if (accountOut.FreeTransactions == 0)
                {
                    App.AccountRepo.MoneyOut(item.AccountOut, accountOut.TransFee);
                }
                else
                {
                    App.AccountRepo.FreeTrans(accountOut);
                }

                int v = conn.Insert(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Deposit(Transaction item)
        {
            Account accountIn = App.AccountRepo.GetAccountFromId(item.AccountIn);
            try
            {
                Init();

                
                
                if (accountIn.FreeTransactions == 0)
                {
                    App.AccountRepo.MoneyOut(item.AccountIn, accountIn.TransFee);
                }
                if (accountIn.FreeTransactions > 0)
                {

                    App.AccountRepo.FreeTrans(accountIn);
                }
                App.AccountRepo.MoneyIn(item.AccountIn, item.TransactionAmount);
                int v = conn.Insert(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public double GetFundsTotal()
        {
            Init();
            return conn.Table<Transaction>().Sum(r => r.TransactionAmount);

        }

        public void Transfer(Transaction item)
        {
            Account accountIn = App.AccountRepo.GetAccountFromId(item.AccountIn);
            Account accountOut = App.AccountRepo.GetAccountFromId(item.AccountOut);

            try
            {
                Init();

                App.AccountRepo.MoneyOut(item.AccountOut, item.TransactionAmount);
                App.AccountRepo.MoneyIn(item.AccountIn, item.TransactionAmount);

                if (accountOut.FreeTransactions == 0)
                {
                    App.AccountRepo.MoneyOut(item.AccountOut, accountOut.TransFee);
                }
                else
                {
                    App.AccountRepo.FreeTrans(accountOut);
                }

                if (accountIn.FreeTransactions == 0)
                {
                    App.AccountRepo.MoneyOut(item.AccountIn, accountIn.TransFee);
                }
                else
                {
                    App.AccountRepo.FreeTrans(accountIn);
                }

                int v = conn.Insert(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }


}

