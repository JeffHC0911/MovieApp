using MovieApp.WPF.Services;
using MovieApp.WPF.ViewModels.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MovieApp.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public event Action? OnLoginSuccess;
        public event Action? OnRegisterRequested;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async () =>
            {
                var success = await AuthService.LoginAsync(Email, Password);
                if (success)
                    OnLoginSuccess?.Invoke();
                else
                    MessageBox.Show("Login fallido");
            });

            GoToRegisterCommand = new RelayCommand(() =>
            {
                OnRegisterRequested?.Invoke();
            });
        }
    }

}
