namespace Bankr.Views;

//using Android.App;
using Bankr.Data;
using Bankr.Model;

public partial class Customers : ContentPage
{
    public Customers()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        BankrDatabase database = await BankrDatabase.Instance;
        collectionView.ItemsSource = await database.GetCustomersAsync();
    }
    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AddCustomer");

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