namespace Bankr;
using Bankr.Service;

public partial class App : Application
{
    public static ClientRepository ClientRepo { get; private set; }
    public static StaffRepository StaffRepo { get; private set; }


    public App(ClientRepository clientRepo, StaffRepository staffRepo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        //Initialising our user repo
        ClientRepo = clientRepo;
        StaffRepo = staffRepo;

    }
}
