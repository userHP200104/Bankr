namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;
public partial class AddCustomerView : ContentPage
{
    public AddCustomerView()
    {
        //BindingContext = bankrDatabase;
        InitializeComponent();
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        string name = entryname.Text;
        string surname = entrysurname.Text;
        

        var people = new People() { name = name, surname = surname, role = "Customer" };
        Console.WriteLine(people);
        BankrDatabase database = await BankrDatabase.Instance;

        await database.SavePeopleAsync(people);
        await Shell.Current.GoToAsync("//Customers");
    }
}