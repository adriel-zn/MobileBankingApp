using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using Microsoft.Extensions.Logging;

namespace BankingApp.MAUI
{
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

            //builder.Services.AddSingleton<IAbsaBankService, AbsaBankService>();
            
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<MainPage>();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
