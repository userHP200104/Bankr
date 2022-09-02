using System.Diagnostics;
using Bankr.Model;
using Microsoft.Maui.Graphics.Text;

namespace Bankr.Views;

public partial class DepositView : ContentPage
{
	public DepositView()
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

        double amount=double.Parse((string)AmountInput.Text);
        Debug.WriteLine(amount);
        Transaction transaction = new Transaction()
        {
            AccountOut = 0,
            AccountIn = accountid,
            TransactionAmount = amount,
            TransactionType="deposit",
        };
        App.TransactionRepo.Deposit(transaction);
        await Navigation.PopAsync();
    }
    }