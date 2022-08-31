namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;


//[QueryProperty(nameof(ClientId), "ClientId")]
public partial class AccountDetailView : ContentPage
{
    //public string ClientId { get => ClientId; set { ClientId = value; OnPropertyChanged(); } }
    public AccountDetailView()
    {
        InitializeComponent();
        //BindingContext = this;
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

            AccountHolder.Text = Client.Name + " " + Client.Surname;
            AccountNumber.Text = Account.Id.ToString();
            AccountBalance.Text = Account.Balance.ToString();
            AccountType.Text=Account.AccountType.ToString();

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
    private async void OnAddClicked(object sender, EventArgs e)
    {
        string ClientId = this.BindingContext.ToString();
        int clientid = int.Parse((string)ClientId);

        await Navigation.PushAsync(new AddAccountView
        {
            BindingContext = clientid
        });

    }
    private async void OnEditClicked(object sender, EventArgs e)
    {
        string ClientId = this.BindingContext.ToString();
        int clientid = int.Parse((string)ClientId);

        await Navigation.PushAsync(new ClientDetailView
        {
            BindingContext = clientid

        });
    }

    private async void OnAccountClicked(object sender, SelectionChangedEventArgs e)
    {
        string accountid = (e.CurrentSelection.FirstOrDefault() as Account)?.Id.ToString();

        await Navigation.PushAsync(new AccountDetailView
        {
            BindingContext = accountid
        });
    }

    private async void OnAddTransactionClicked(object sender, EventArgs e)
    {
        string SenderId = this.BindingContext.ToString();
        int senderid = int.Parse((string)SenderId);

        await Navigation.PushAsync(new CreateTransactionView
        {
            BindingContext = senderid
        });

    }
}