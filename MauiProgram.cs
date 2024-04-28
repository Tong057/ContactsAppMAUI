using CommunityToolkit.Maui;
using ContactsAppMAUI.Data;
using ContactsAppMAUI.Models;
using ContactsAppMAUI.ViewModels;
using ContactsAppMAUI.Views;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;

namespace ContactsAppMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBottomSheet()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ApplicationContext>();
            builder.Services.AddSingleton<ContactRepository>();

            builder.Services.AddTransient<ContactListViewModel>();
            builder.Services.AddTransient<ContactViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<EditContactPage>();
            builder.Services.AddTransient<AddContactPage>();
            builder.Services.AddTransient<FilterBottomSheet>();

            return builder.Build();
        }
    }
}
