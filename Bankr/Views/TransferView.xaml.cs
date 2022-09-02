using System.Diagnostics;
using Bankr.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics.Text;

namespace Bankr.Views;

public partial class TransferView : ContentPage
{
	public TransferView()
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
        int receivingAccountId = int.Parse((string)AccountIdInput.Text);
        Debug.WriteLine(amount);
        Transaction transaction = new Transaction()
        {
            AccountOut = accountid,
            AccountIn = receivingAccountId,
            TransactionAmount = amount,
            TransactionType = "transfer",
        };

        Debug.WriteLine("AccountIn" + transaction.AccountIn);
        Debug.WriteLine("AccountOut" + transaction.AccountOut);
        Debug.WriteLine("amount" + transaction.TransactionAmount);

        App.TransactionRepo.Transfer(transaction);
        await Navigation.PopAsync();
    }
}
