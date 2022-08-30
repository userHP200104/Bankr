namespace Bankr.Views;
//using Bankr.Data;
using Bankr.Service;
using Bankr.Model;
using Bankr.ViewModels;
using Bankr.Data;
using Microsoft.Maui.Controls;

public partial class StaffView : ContentPage
{
    StaffViewModel vm = new StaffViewModel();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Staff> staff= App.StaffRepo.GetStaff();
        
        StaffCollection.ItemsSource = staff;
    }
    public StaffView()
    { 
        InitializeComponent();
        //use our viewModel to bind data on this View
        BindingContext = vm;
        

    }


    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddStaffView { });

    }

    private async void OnStaffClicked(object sender, SelectionChangedEventArgs e)
    {
        string staffid = (e.CurrentSelection.FirstOrDefault() as Staff)?.Id.ToString();

        await Navigation.PushAsync(new StaffDetailView
        {
            BindingContext = staffid
        });
    }
}