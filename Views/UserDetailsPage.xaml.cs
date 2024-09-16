using CommunityToolkit.Mvvm.Input;
using MyFirstMAUIApp.ViewModels;

namespace MyFirstMAUIApp.Views;

public partial class UserDetailsPage : ContentPage
{
	public UserDetailsPage(UserDetailsViewModel userDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = userDetailsViewModel;
	}


}