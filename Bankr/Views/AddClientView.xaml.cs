namespace Bankr.Views;
//using Bankr.Data;
using Bankr.Service;
using Bankr.Model;
using Bankr.ViewModels;

public partial class AddClientView : ContentPage
{
    ClientViewModel vm = new ClientViewModel();
    public AddClientView()
    {
        InitializeComponent();
        //use our viewModel to bind data on this View
        BindingContext = vm;

    }
    async void OnClientClicked(object sender, EventArgs e)
    {
        vm.AddClient();
        await Shell.Current.GoToAsync("//Clients");
    }
}