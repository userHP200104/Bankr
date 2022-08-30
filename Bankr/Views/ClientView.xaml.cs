namespace Bankr.Views;
//using Bankr.Data;
using Bankr.Service;
using Bankr.Model;
using Bankr.ViewModels;
using Bankr.Data;
using Microsoft.Maui.Controls;

public partial class ClientView : ContentPage
{
    ClientViewModel vm = new ClientViewModel();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Client> clients = App.ClientRepo.GetClientsAsync();

        collectionView.ItemsSource = clients;
    }
    public ClientView()
    {
        InitializeComponent();
        //use our viewModel to bind data on this View
        BindingContext = vm;


    }


    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddClientView { });

    }

    private async void OnAccountClicked(object sender, SelectionChangedEventArgs e)
    {
        string clientid = (e.CurrentSelection.FirstOrDefault() as People)?.Id.ToString();

        await Navigation.PushAsync(new Accounts
        {
            BindingContext = clientid
        });
    }
    }

