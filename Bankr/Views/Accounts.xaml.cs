namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;


//[QueryProperty(nameof(ClientId), "ClientId")]
public partial class Accounts : ContentPage
{
    //public string ClientId { get => ClientId; set { ClientId = value; OnPropertyChanged(); } }
    public Accounts()
    {
        InitializeComponent();
        //BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        string ClientId =this.BindingContext.ToString();
        base.OnAppearing();
        BankrDatabase database = await BankrDatabase.Instance;
        int clientid = int.Parse((string)ClientId);

        People Client = await database.GetPeopleFromIdAsync(clientid);
        ClientName.Text=Client.Name+" "+Client.Surname;
        listView.ItemsSource = await database.GetAccountsAsync(ClientId);
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
}