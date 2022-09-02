namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;
using Bankr.Service;

//[QueryProperty(nameof(ClientId), "ClientId")]
public partial class AccountsView : ContentPage
{
    //public string ClientId { get => ClientId; set { ClientId = value; OnPropertyChanged(); } }
    public AccountsView()
    {
        InitializeComponent();
        //BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        string ClientId =this.BindingContext.ToString();
        base.OnAppearing();
        int clientid = int.Parse((string)ClientId);
        Client Client;

        if (App.ClientRepo.GetClientFromId(clientid)!=null)
        {
            Client = App.ClientRepo.GetClientFromId(clientid);
            ClientName.Text = Client.Name + " " + Client.Surname;

            if (App.AccountRepo.GetAccountsForClient(clientid) != null) {
                List<Account> AccountList = App.AccountRepo.GetAccountsForClient(clientid);
                collectionView.ItemsSource = AccountList;
            }

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

        }) ;
    }

    private async void OnAccountClicked(object sender, SelectionChangedEventArgs e)
    {
        string accountid = (e.CurrentSelection.FirstOrDefault() as Account)?.Id.ToString();

        await Navigation.PushAsync(new AccountDetailView
        {
            BindingContext = accountid
        });
    }
}