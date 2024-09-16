using MyFirstMAUIApp.ViewModels;

namespace MyFirstMAUIApp.Views;

public partial class ManageUserPage : ContentPage
{
	public ManageUserPage(ManageUserViewModel manageUserViewModel)
	{
		InitializeComponent();
		BindingContext = manageUserViewModel;

    }
}