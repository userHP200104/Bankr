namespace Bankr;
using Bankr.Service;

public partial class App : Application
{
    public static ClientRepository ClientRepo { get; private set; }
    public static StaffRepository StaffRepo { get; private set; }

    public static AccountRepository AccountRepo { get; private set; }

    public static TransactionRepository TransactionRepo { get; private set; }

    public App(ClientRepository clientRepo, StaffRepository staffRepo, AccountRepository accountRepo, TransactionRepository transactionRepo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        //Initialising our user repo
        ClientRepo = clientRepo;
        StaffRepo = staffRepo;
        AccountRepo = accountRepo;
        TransactionRepo = transactionRepo;

    }
}
