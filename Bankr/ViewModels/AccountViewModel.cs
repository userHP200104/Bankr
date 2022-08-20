using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bankr.ViewModels
{
	public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        int id;

        [ObservableProperty]
        float balance;

        [ObservableProperty]
        string accountType;

        [ObservableProperty]
        float intrest;

        [ObservableProperty]
        float transactionFee;

        [ObservableProperty]
        int userId;

        [ObservableProperty]
        int transactionId;
    }
}

