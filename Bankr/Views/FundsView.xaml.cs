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

        totalRollover.Text = String.Format("{0:n}", setRollover);
        totalTransactionFee.Text = String.Format("{0:n}", setTransactionFee);
        totalInterestPaid.Text = String.Format("{0:n}", setIntrest);
        netTotal.Text = String.Format("{0:n}", setNetTotal);

        Debug.WriteLine("Total Clients " + setRollover);
        Debug.WriteLine("Total Admins " + setTransactionFee);
        Debug.WriteLine("Total Accounts " + setIntrest);
        Debug.WriteLine("Total Funds " + setNetTotal);
    }
}
