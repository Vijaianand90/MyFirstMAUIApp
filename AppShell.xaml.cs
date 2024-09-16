using MyFirstMAUIApp.Views;

namespace MyFirstMAUIApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManageUserPage), typeof(ManageUserPage));
	}
}
