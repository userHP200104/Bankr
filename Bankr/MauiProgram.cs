using Bankr.Services;
using Bankr.ViewModels;
using Bankr.Views;

namespace Bankr;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("SF-Pro-Display-Ultralight.otf", "SFProDisplayUltralight");
				fonts.AddFont("SF-Pro-Display-Thin.otf", "SFProDisplayThin");
				fonts.AddFont("SF-Pro-Display-Light.otf", "SFProDisplayLight");
				fonts.AddFont("SF-Pro-Display-Regular.otf", "SFProDisplayRegular");
				fonts.AddFont("SF-Pro-Display-Medium.otf", "SFProDisplayMedium");
				fonts.AddFont("SF-Pro-Display-Semibold.otf", "SFProDisplaySemibold");
				fonts.AddFont("SF-Pro-Display-Bold.otf", "SFProDisplayBold");
				fonts.AddFont("SF-Pro-Display-Heavy.otf", "SFProDisplayHeavy");
				fonts.AddFont("SF-Pro-Display-Black.otf", "SFProDisplayBlack");
				
				
			});

        // View & VeiwsModel

        builder.Services.AddSingleton<Home>();
        builder.Services.AddSingleton<Login>();

        builder.Services.AddSingleton<SingleAccount>();
        builder.Services.AddSingleton<AccountViewModel>();

        //builder.Services.AddSingleton<Accounts>();
        builder.Services.AddSingleton<Staff>();
        builder.Services.AddSingleton<UserViewModel>();

        builder.Services.AddSingleton<Funds>();
        builder.Services.AddSingleton<TransactionViewModel>();

        //DB Repo's

        string userDbPath = FileAccessHelper.GetLocalFielPath("projectDatabase.db3");
        builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, userDbPath));
        builder.Services.AddSingleton<AccountRepository>(s => ActivatorUtilities.CreateInstance<AccountRepository>(s, userDbPath));
        builder.Services.AddSingleton<TransactionRepository>(s => ActivatorUtilities.CreateInstance<TransactionRepository>(s, userDbPath));

        return builder.Build();
	}
}

