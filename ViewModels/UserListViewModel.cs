using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using MyFirstMAUIApp.Models;
using MyFirstMAUIApp.Services;
using MyFirstMAUIApp.Views;

namespace MyFirstMAUIApp.ViewModels
{

    public partial class UserListViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableRangeCollection<User> Users { get; set; } = new();
        private readonly IUserService userService;

        public UserListViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        private async Task LoadUserFromDatabase()
        {
            var users = await userService.GetAsync();
            if(Users.Count > 0)
            {
                Users.Clear();
            }

            if(Users.Count == 0) {
                Users.AddRange(users);
            }

        }

        [RelayCommand]
        public async Task AddUser()
        {
            await AppShell.Current.GoToAsync(nameof(ManageUserPage));
        }

        [RelayCommand]
        public async Task DisplayActionSheet(User user)
        {
            if(user == null) { return; }

            var response = await Shell.Current.DisplayActionSheet("Select Action", "Ok", null, "Edit", "Delete");
            var navigationParameter = new Dictionary<string, Object>();
            navigationParameter.Add("UserDetails", user);
            if (response == "View") {
                await Shell.Current.GoToAsync(nameof(UserListPage), navigationParameter);
            }
            else if(response == "Edit")
            {
     
                await Shell.Current.GoToAsync(nameof(ManageUserPage),navigationParameter);
            }
            else if(response == "Delete")
            {
                var result = await userService.DeleteAsync(user);
                if(result > 0)
                {
                    await CreateToastNotification("Deleted Successfully");
                }
            }
        }

        private async Task CreateToastNotification(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
