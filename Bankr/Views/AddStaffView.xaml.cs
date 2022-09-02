namespace Bankr.Views;
//using Bankr.Data;
using Bankr.Service;
using Bankr.Model;
using Bankr.ViewModels;

public partial class AddStaffView : ContentPage
{
    StaffViewModel vm = new StaffViewModel();
    public AddStaffView()
    {
        InitializeComponent();
        //use our viewModel to bind data on this View
        BindingContext = vm;

    }
    async void  AddStaffClicked(object sender, EventArgs e)
    {
        vm.AddStaff();
        await Shell.Current.GoToAsync("//Staff");
    }
}