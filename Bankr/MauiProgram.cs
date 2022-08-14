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

		return builder.Build();
	}
}

