using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bankr.ViewModels
{
	public partial class UserViewModel : ObservableObject
    {

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string surname;

        [ObservableProperty]
        string role;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string accountId;

    }
}

