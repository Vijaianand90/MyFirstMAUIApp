using MyFirstMAUIApp.ViewModels;

namespace MyFirstMAUIApp.Views;

public partial class UserListPage : ContentPage
{
	private readonly UserListViewModel userListViewModel;
	public UserListPage(UserListViewModel userListViewModel)
	{
		InitializeComponent();
		BindingContext = userListViewModel;
		this.userListViewModel = userListViewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		this.userListViewModel.LoadUserFromDatabaseCommand.Execute(null);
    }
}