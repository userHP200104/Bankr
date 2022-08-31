using System.Diagnostics;
using Bankr.Model;
using Microsoft.Maui.Graphics.Text;

namespace Bankr.Views;

public partial class WithdrawView : ContentPage
{
	public WithdrawView()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        string AccountId = this.BindingContext.ToString();
        int accountid = int.Parse((string)AccountId);
        base.OnAppearing();

    }
    async void OnEnterClicked(object sender, EventArgs e)
    {
        // string Amount= AmountInput.Text;
        string AccountId = this.BindingContext.ToString();
        int accountid = int.Parse((string)AccountId);

        double amount = double.Parse((string)AmountInput.Text);
        Debug.WriteLine(amount);
        Transaction transaction = new Transaction()
        {
            AccountOut = accountid,
            AccountIn = 0,
            TransactionAmount = amount,
            TransactionType = "withdrawal"
        };
        App.TransactionRepo.Withdrawal(transaction);
        await Navigation.PopAsync();
    }
}
