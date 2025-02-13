using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using BankingApp.MAUI.Views;
using BankingApp.Shared.Models;
using Microsoft.Extensions.Logging;

namespace BankingApp.MAUI;

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


        builder.Services.AddTransient<IAbsaBankService, AbsaBankService>();

        builder.Services.AddSingleton<BeneficiaryViewModel>();
        builder.Services.AddSingleton<AccountViewModel>();

        builder.Services.AddSingleton<PaymentPage>();
        builder.Services.AddSingleton<ResultPage>();
        builder.Services.AddSingleton<ReviewPage>();
        builder.Services.AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif


        return builder.Build();
	}
}
