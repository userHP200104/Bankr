﻿using Bankr.Service;
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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Views & ViewModels
        builder.Services.AddSingleton<StaffView>();
        builder.Services.AddSingleton<StaffViewModel>();

        builder.Services.AddSingleton<ClientView>();
        builder.Services.AddSingleton<ClientViewModel>();

       // builder.Services.AddSingleton<Accounts>();
       // builder.Services.AddSingleton<TodoViewModel>();


        //DB Repos
        string userDbPath = FileAccessHelper.GetLocalFilePath("projectDatabase.db3");
        builder.Services.AddSingleton<ClientRepository>(s => ActivatorUtilities.CreateInstance<ClientRepository>(s, userDbPath));
        builder.Services.AddSingleton<StaffRepository>(s => ActivatorUtilities.CreateInstance<StaffRepository>(s, userDbPath));

        return builder.Build();
	}
}

