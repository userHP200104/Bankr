namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;

public partial class Staff : ContentPage
{
	public Staff()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		BankrDatabase database = await BankrDatabase.Instance;
		listView.ItemsSource = await database.GetPeopleAsync();
	}
}