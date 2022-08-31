namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;
using Bankr.ViewModels;


//[QueryProperty(nameof(ClientId), "ClientId")]
public partial class ClientDetailView : ContentPage
{
    //public string ClientId { get => ClientId; set { ClientId = value; OnPropertyChanged(); } }
    public ClientDetailView()
    {
        InitializeComponent();
        //BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        string ClientId = this.BindingContext.ToString();
        base.OnAppearing();

        int clientid = int.Parse((string)ClientId);

        Client Client = App.ClientRepo.GetClientFromId(clientid);

        Id.Text = ClientId;

        Name.Placeholder = Client.Name;
        Surname.Placeholder = Client.Surname;
    }
    private async void OnEditClicked(object sender, EventArgs e)
    {
        string ClientId = this.BindingContext.ToString();

        int clientid = int.Parse((string)ClientId);

        string clientname = Name.Text;
        string clientsurname = Surname.Text;

        App.ClientRepo.UpdateClient(clientid, clientname, clientsurname);
        await Navigation.PopAsync();
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        string ClientId = this.BindingContext.ToString();

        int clientid = int.Parse((string)ClientId);

        App.ClientRepo.DeleteClient(clientid);
        await Navigation.PopAsync();
    }
}