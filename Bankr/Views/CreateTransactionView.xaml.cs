using Bankr.ViewModels;
using Bankr.Data;
using Bankr.Model;

namespace Bankr.Views;

public partial class CreateTransactionView : ContentPage
{

	public CreateTransactionView()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
    {
        string AccountId = this.BindingContext.ToString();
        base.OnAppearing();
        int accountid = int.Parse((string)AccountId);
        Account Account;
        Client Client;

        if (App.AccountRepo.GetAccountFromId(accountid) != null)
        {
            Account = App.AccountRepo.GetAccountFromId(accountid);
            Client=App.ClientRepo.GetClientFromId(Account.ClientId);

            //AccountHolder.Text = Client.Name + " " + Client.Surname;
            AccountNumber.Text = Account.Id.ToString();
            AccountType.Text = Account.AccountType.ToString();


            //            if (App.AccountRepo.GetTransactionsForAccount(accountid) != null)
            //{
            //    List<Account> AccountList = App.AccountRepo.GetAccountsForClient(clientid);
            //    listView.ItemsSource = AccountList;
            // }

        }
        else
        {
            Navigation.PopAsync();
        }



        //listView.ItemsSource = await database.GetAccountsAsync(ClientId);
    }
}
