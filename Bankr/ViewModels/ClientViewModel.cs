using Bankr;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bankr.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankr.Data;
using Microsoft.Maui.Controls;
//using static Android.Provider.ContactsContract;

namespace Bankr.ViewModels
{
    public partial class ClientViewModel : ObservableObject
    {

        public ClientViewModel()
        {
            Clients = new ObservableCollection<Client>(App.ClientRepo.GetClientsAsync());
            Client = new Client();

            // ListOfStaff = new List<Staff>(App.StaffRepo.GetStaff());
            // TotalTodos = App.TodoRepo.GetTotalTodos();
        }


        [ObservableProperty]
        Client client;

        //entry field
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string surname;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        Staff selectedClient;

        [ObservableProperty]
        ObservableCollection<Client> clients;

        public void AddClient()
        {
            Client.Name = name;
            Client.Surname = surname;


            try
            {
                App.ClientRepo.SaveClientAsync(Client);
                // Staffmembers.Clear();

                // Staffmembers = new ObservableCollection<Staff>(App.StaffRepo.GetStaff());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        [RelayCommand]
        public void DeleteClient()
        {

            App.StaffRepo.DeleteStaff(6);
            App.StaffRepo.DeleteStaff(7);
            App.StaffRepo.DeleteStaff(8);

            Clients = new ObservableCollection<Client>(App.ClientRepo.GetClientsAsync());

            Shell.Current.GoToAsync("//ClientView");
        }


    }
}
