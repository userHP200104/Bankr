using Bankr.Data;
using Bankr.Model;
//using Org.Apache.Http.Client.Params;

namespace Bankr.Views;

public partial class AddAccountView : ContentPage
{
	public AddAccountView()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        string ClientId = this.BindingContext.ToString();
        base.OnAppearing();
        int clientid = int.Parse((string)ClientId);

        Client Client = App.ClientRepo.GetClientFromId(clientid);
        ClientName.Text = "New Account For: "+Client.Name + " " + Client.Surname;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        string ClientId = this.BindingContext.ToString();
        int clientid = int.Parse((string)ClientId);

        string accounttype = accountType.SelectedItem.ToString();

        double transFee=0;
        int freeTrans=0;
        double interest=0;

        //Info Block based on account selected

        if (accounttype == "Gold Cheque") {
            transFee = 15.00;
            freeTrans = 10;
            interest = 0;
            Description1.Text = "Transaction Fee: R15";
            Description2.Text = "10 Free Transactions per Month";
            Description3.Text = "0% Monthly Interest";

        }

        else if (accounttype == "Diamond Cheque") {
            transFee = 20.00;
            freeTrans = 30;
            interest = 0;
            Description1.Text = "Transaction Fee: R20";
            Description2.Text = "30 Free Transactions per Month";
            Description3.Text = "0% Monthly Interest";
        }

        else if (accounttype == "Tax Free Savings") {
            transFee = 40.00;
            freeTrans = 0;
            interest = 0.12;
            Description1.Text = "Transaction Fee: R40";
            Description2.Text = "0 Free Transactions per Month";
            Description3.Text = "12% Monthly Interest";
        }

        else if (accounttype == "Easy Access Savings") {
            transFee = 30.00;
            freeTrans = 0;
            interest = 0.08;
            Description1.Text = "Transaction Fee: R30";
            Description2.Text = "0 Free Transactions per Month";
            Description3.Text = "8% Monthly Interest";
        }

        else if (accounttype == "Credit")
        {
            transFee = 0.00;
            freeTrans = 0;
            interest = 0.00;
            Description1.Text = "Transaction Fee: 0";
            Description2.Text = "0 Free Transactions per Month";
            Description3.Text = "12% Monthly Interest on Debt";
        }

        var account = new Account { AccountType = accounttype, Balance=0, FreeTransactions=freeTrans, TransFee=transFee, Interest=interest, ClientId = clientid };
        Console.WriteLine(account);
        App.AccountRepo.AddAccount(account);
        await Navigation.PopAsync();
    }
}