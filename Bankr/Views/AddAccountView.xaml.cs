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
        BankrDatabase database = await BankrDatabase.Instance;
        int clientid = int.Parse((string)ClientId);

        People Client = await database.GetPeopleFromIdAsync(clientid);
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

        if (accounttype == "Gold Cheque") {
            transFee = 15.00;
            freeTrans = 10;
            interest = 0;

        }

        else if (accounttype == "Diamond Cheque") {
            transFee = 20.00;
            freeTrans = 30;
            interest = 0;
        }

        else if (accounttype == "Tax Free Savings") {
            transFee = 40.00;
            freeTrans = 0;
            interest = 0.12;
        }

        else if (accounttype == "Easy Access Savings") {
            transFee = 30.00;
            freeTrans = 0;
            interest = 0.08;
        }

        else if (accounttype == "Credit")
        {
            transFee = 0.00;
            freeTrans = 0;
            interest = 0.00;
        }

        var account = new Account { accountType = accounttype, balance=0, freeTransactions=freeTrans, transFee=transFee, interest=interest, clientId = clientid };
        Console.WriteLine(account);
        BankrDatabase database = await BankrDatabase.Instance;

        await database.SaveAccountAsync(account);
        await Navigation.PopAsync();
    }
}