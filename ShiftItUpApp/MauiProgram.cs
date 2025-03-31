using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ShiftItUpApp.ViewModels;
using ShiftItUpApp.Views; // Make sure you import the Views namespace
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
            // Disambiguate WeekScheduleView (from Views namespace)
            builder.Services.AddTransient<Views.WeekScheduleView>();  // Explicitly using the Views namespace
            builder.Services.AddTransient<ProfileView>();
            builder.Services.AddTransient<ContactsListView>();
            builder.Services.AddTransient<SubmitShiftsView>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<RegisterStoreView>();
            builder.Services.AddTransient<EmployeeApprovalsView>();
            builder.Services.AddTransient<ManagerEditWorker>();
            builder.Services.AddTransient<EditingShiftsScheduleView>();

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
            builder.Services.AddTransient<WeekScheduleViewModel>(); // The ViewModel should stay as is
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ContactsListViewModel>();
            builder.Services.AddTransient<SubmitShiftsViewModel>();
            builder.Services.AddTransient<ViewModelBase>();
            builder.Services.AddTransient<RegisterStoreViewModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<EmployeeApprovalsViewModel>();
            builder.Services.AddTransient<ManagerEditWorkerViewModel>();
            builder.Services.AddTransient<EditingShiftsScheduleViewModel>();
            return builder;
        }
    }
}
