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
    public partial class StaffViewModel : ObservableObject
    {

        public StaffViewModel()
        {
            Staffmembers = new ObservableCollection<Staff>(App.StaffRepo.GetStaff());
            Staffmember = new Staff();

           // ListOfStaff = new List<Staff>(App.StaffRepo.GetStaff());
           // TotalTodos = App.TodoRepo.GetTotalTodos();
        }


        [ObservableProperty]
        Staff staffmember;

        //entry field
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string surname;

        [ObservableProperty]
        string role;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        Staff selectedStaff;

        [ObservableProperty]
        ObservableCollection<Staff> staffmembers;

        public void AddStaff()
        {
            Staffmember.Name= name;
            Staffmember.Surname= surname;
            Staffmember.Role= role;


            try
            {
               App.StaffRepo.SaveStaff(Staffmember);
               // Staffmembers.Clear();

               // Staffmembers = new ObservableCollection<Staff>(App.StaffRepo.GetStaff());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        [RelayCommand]
        public void DeleteStaff()
        {

            App.StaffRepo.DeleteStaff(6);
            App.StaffRepo.DeleteStaff(7);
            App.StaffRepo.DeleteStaff(8);

            Staffmembers = new ObservableCollection<Staff>(App.StaffRepo.GetStaff());

            Shell.Current.GoToAsync("//Staff");
        }

        public List<Staff> GetStaff()
        {
            return Staffmembers.ToList();   
        }

    }
}
