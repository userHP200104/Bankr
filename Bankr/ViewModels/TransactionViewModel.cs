using Bankr;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bankr.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankr.Data;
using Microsoft.Maui.Controls;

namespace Bankr.ViewModels
{
	public partial class TransactionViewModel: ObservableObject
    {
		//public TransactionViewModel()
		//{
  //          Transactions = new ObservableCollection<Transaction>(App.TransactionRepo.GetTransactionsAsync());
  //          Transaction = new Transaction();
  //      }

        [ObservableProperty]
        Transaction transaction;

        [ObservableProperty]
        int accountIn;

        [ObservableProperty]
        int accountOut;

        [ObservableProperty]
        int transactionAmount;

        [ObservableProperty]
        string transactionType;

        [ObservableProperty]
        ObservableCollection<Transaction> transactions;
    }
}

