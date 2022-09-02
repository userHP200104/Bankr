using Bankr.Data;
using Bankr.Model;
using Bankr.ViewModels;
using Microsoft.Maui.Controls;

namespace Bankr.Views;


public partial class AccountDetailView : ContentPage
{

    TransactionViewModel vm = new TransactionViewModel();


    protected override async void OnAppearing()
    {
        string AccountId = this.BindingContext.ToString();
        base.OnAppearing();
        List<Transaction> transactions = App.TransactionRepo.GetTransactionsAsync(int.Parse(AccountId));

        Transactions.ItemsSource = transactions;

        int accountid = int.Parse((string)AccountId);
        Account Account;
        Client Client;


        if (App.AccountRepo.GetAccountFromId(accountid) != null)
        {
            Account = App.AccountRepo.GetAccountFromId(accountid);
            Client=App.ClientRepo.GetClientFromId(Account.ClientId);

            AccountHolder.Text = Client.Name + " " + Client.Surname;
            AccountNumber.Text = Account.Id.ToString();
            AccountBalance.Text = Account.Balance.ToString();
            AccountType.Text=Account.AccountType.ToString();
            FreeTransactions.Text = Account.FreeTransactions.ToString();
            TransactionFee.Text=Account.TransFee.ToString();

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

    public AccountDetailView()
    {
        InitializeComponent();
        //BindingContext = this;
        BindingContext = vm;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        string AccountId = this.BindingContext.ToString();
        int accountid = int.Parse((string)AccountId);

        App.AccountRepo.DeleteAccount(accountid);
        Navigation.PopAsync();
    }

    private async void OnDepositClicked(object sender, EventArgs e)
    {
        string AccountId = this.BindingContext.ToString();

        await Navigation.PushAsync(new DepositView
        {
            BindingContext = AccountId
        }) ;

        List<Transaction> transactions = App.TransactionRepo.GetTransactionsAsync(int.Parse(AccountId));

        Transactions.ItemsSource = transactions;
    }
    private async void OnWithdrawClicked(object sender, EventArgs e)
    {
        string AccountId = this.BindingContext.ToString();

        await Navigation.PushAsync(new WithdrawView
        {
            BindingContext = AccountId
        });

        List<Transaction> transactions = App.TransactionRepo.GetTransactionsAsync(int.Parse(AccountId));

        Transactions.ItemsSource = transactions;
    }
    private async void OnTransferClicked(object sender, EventArgs e)
    {
        string AccountId = this.BindingContext.ToString();

        await Navigation.PushAsync(new TransferView
        {
            BindingContext = AccountId
        });

        List<Transaction> transactions = App.TransactionRepo.GetTransactionsAsync(int.Parse(AccountId));

        Transactions.ItemsSource = transactions;
    }
}