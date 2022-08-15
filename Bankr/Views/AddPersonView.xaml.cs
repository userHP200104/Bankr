namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;
public partial class AddPersonView : ContentPage
{
	public AddPersonView()
	{
		//BindingContext = bankrDatabase;
		InitializeComponent();
	}

	async void OnSaveClicked(object sender, EventArgs e )
	{
		string name = entryname.Text;
		string surname=entrysurname.Text;
		string role=entryrole.Text;

		var people = new People() { name = name, surname=surname, role=role };
		Console.WriteLine(people);
		BankrDatabase database=await BankrDatabase.Instance;

		await database.SavePeopleAsync(people);
        await Shell.Current.GoToAsync("//Staff");
    }
}