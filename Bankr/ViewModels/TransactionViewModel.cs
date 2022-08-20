using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bankr.ViewModels
{
	public partial class TransactionViewModel : ObservableObject
    {
        [ObservableProperty]
        int id;

        [ObservableProperty]
        float amount;

        [ObservableProperty]
        string transactionType;

        [ObservableProperty]
        float transactionCost;

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        int accountInId;

        [ObservableProperty]
        int accountOutId;
    }
}

