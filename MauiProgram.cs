using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyFirstMAUIApp.Services;
using MyFirstMAUIApp.ViewModels;
using MyFirstMAUIApp.Views;
using Syncfusion.Maui.Core.Hosting;

namespace MyFirstMAUIApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddTransient<IUserService, UserService>();

        builder.Services.AddTransient<UserListPage>();
        builder.Services.AddTransient<UserListViewModel>();

        builder.Services.AddTransient<ManageUserPage>();
        builder.Services.AddTransient<ManageUserViewModel>();

        builder.Services.AddTransient<UserDetailsPage>();
        builder.Services.AddTransient<UserDetailsViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
