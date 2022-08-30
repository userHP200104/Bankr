namespace Bankr.Views;
using Bankr.Data;
using Bankr.Model;
using Bankr.ViewModels;


//[QueryProperty(nameof(ClientId), "ClientId")]
public partial class StaffDetailView : ContentPage
{
    //public string ClientId { get => ClientId; set { ClientId = value; OnPropertyChanged(); } }
    public StaffDetailView()
    {
        InitializeComponent();
        //BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        string StaffId = this.BindingContext.ToString();
        base.OnAppearing();

        int staffid = int.Parse((string)StaffId);

        Staff StaffMember = App.StaffRepo.GetStaffFromId(staffid);

        Id.Text = StaffId;
       
        Name.Placeholder=StaffMember.Name;
        Surname.Placeholder=StaffMember.Surname;
        Role.Placeholder=StaffMember.Role;
    }
    private async void OnEditClicked(object sender, EventArgs e)
    {
        string StaffId = this.BindingContext.ToString();

        int staffid = int.Parse((string)StaffId);

        string staffname = Name.Text; 
        string staffrole=Surname.Text;
        string staffsurname=Role.Text;

        App.StaffRepo.UpdateStaff(staffid, staffname, staffsurname, staffrole);
        await Navigation.PopAsync();
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        string StaffId = this.BindingContext.ToString();

        int staffid = int.Parse((string)StaffId);

        App.StaffRepo.DeleteStaff(staffid);
        await Navigation.PopAsync();

    }
    }