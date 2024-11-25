using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ShiftItUpApp.ViewModels;
using ShiftItUpApp.Views;
using ShiftItUptApp.Services;
using CommunityToolkit.Maui;


namespace ShiftItUpApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Cinematografica-Regular-trial.ttf", "CinematograficaRegulartrial");
                    fonts.AddFont("secrcode.ttf", "secrcode");

                })
                .RegisterDataServices()
                .RegisterPages()
                .RegisterViewModels();
           

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<RegisterView>();
            return builder;
        }

        public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<ShiftItUptWebAPIProxy>();
            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ViewModelBase>();
            return builder;
        }
    }
}
