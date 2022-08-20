namespace Bankr.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void LogIn(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
    }
}
