using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyFirstMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyFirstMAUIApp.ViewModels
{
    [QueryProperty(nameof(NewUserModel) , "UserDetails")]
    public partial class UserDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _newUserModel;

        [RelayCommand]
        public async Task Home()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
