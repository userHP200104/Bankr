namespace Bankr.Views;

public partial class Accounts : ContentPage
{
	public Accounts()
	{
		InitializeComponent();
	}

    private async void GoToAccount(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SingleAccount");

    }
}