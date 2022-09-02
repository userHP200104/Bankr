using System.Diagnostics;
using Bankr.Model;
using Bankr.ViewModels;
using Microsoft.Maui.Controls;

namespace Bankr.Views;

public partial class DashboardView : ContentPage
{
    ClientViewModel vm = new ClientViewModel();

    public DashboardView()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int clients = App.ClientRepo.GetClientsTotal();
        int staff = App.StaffRepo.GetStaffTotal();
        int accounts = App.AccountRepo.GetAccountsTotal();

        lblTotalClients.Text = clients.ToString();
        lblTotalAdmin.Text = staff.ToString();
        lblTotalAccounts.Text = accounts.ToString();

        Debug.WriteLine("Total Clients " + clients);
        Debug.WriteLine("Total Admins " + staff);
        Debug.WriteLine("Total Admins " + accounts);
    }
}
