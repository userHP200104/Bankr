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
using Bankr.Service;

namespace Bankr.ViewModels
{
	public partial class TransactionViewModel : ObservableObject
    {
        public TransactionViewModel()
		{
            Transactions = new ObservableCollection<Transaction>(App.TransactionRepo.GetTransactionsAsync());
            Transaction = new Transaction();
        }

        [ObservableProperty]
        Transaction transaction;

        //entry field
        [ObservableProperty]
        int senderId;

        [ObservableProperty]
        string senderAccount;

        [ObservableProperty]
        int receiverId;        

        [ObservableProperty]
        string receiverAccount;

        [ObservableProperty]
        int amount;

        [ObservableProperty]
        ObservableCollection<Client> clients;

        [ObservableProperty]
        ObservableCollection<Account> accounts;

        public ObservableCollection<Transaction> Transactions { get; }
    }
}

