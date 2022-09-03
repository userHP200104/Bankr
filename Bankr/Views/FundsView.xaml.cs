using System.Diagnostics;

namespace Bankr.Views;

public partial class FundsView : ContentPage
{
	public FundsView()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        double setRollover= App.TransactionRepo.GetRollover();
        double setTransactionFee = App.TransactionRepo.GetTransactionFee();
        double setIntrest = App.TransactionRepo.GetInterest();
        double setNetTotal = App.TransactionRepo.GetNetTotal();

        totalRollover.Text = setRollover.ToString();
        totalTransactionFee.Text = setTransactionFee.ToString();
        totalInterestPaid.Text = setIntrest.ToString();
        netTotal.Text = setNetTotal.ToString();

        Debug.WriteLine("Total Clients " + setRollover);
        Debug.WriteLine("Total Admins " + setTransactionFee);
        Debug.WriteLine("Total Accounts " + setIntrest);
        Debug.WriteLine("Total Funds " + setNetTotal);
    }
}
