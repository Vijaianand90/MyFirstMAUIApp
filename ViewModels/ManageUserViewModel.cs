using CommunityToolkit.Mvvm.ComponentModel;
using MyFirstMAUIApp.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using MyFirstMAUIApp.Services;

namespace MyFirstMAUIApp.ViewModels
{
    [QueryProperty(nameof(NewUser), "UserDetails")]
    public partial class ManageUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        User _newUser;

        public ManageUserViewModel(IUserService userService)
        {
            Title = "Manage User";
            _userService = userService;
            NewUser = new User();
        }

        [RelayCommand]
        async Task SaveUserAsync()
        {
            if(NewUser == null) { return; }
            var result = -1;
            if (NewUser.Id > 0) {
                result = await _userService.UpdateAsync(NewUser);
                
            }
            else {
               result = await _userService.AddAsync(NewUser);
                
            }
            if (result > 0)
            {
                await CreateToastNotification("New User Saved");
            }
            else
            {
                await CreateToastNotification("Error in User Data");
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
