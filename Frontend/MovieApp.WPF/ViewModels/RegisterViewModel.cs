using MovieApp.WPF.Services;
using MovieApp.WPF.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace MovieApp.WPF.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;


        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public event Action? OnRegisterSuccess;
        public event Action? OnCancelRegister;

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(async () =>
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    MessageBox.Show("Completa todos los campos");
                    return;
                }

                if (Password != ConfirmPassword)
                {
                    MessageBox.Show("Las contrasenas no coinciden");
                    return;
                }

                var success = await AuthService.RegisterAsync(Email, Password);
                if (success)
                {
                    MessageBox.Show("Registro exitoso. Ahora puedes iniciar sesión.");
                    OnRegisterSuccess?.Invoke();
                }
                else
                {
                    MessageBox.Show("El registro ha fallado. Verifica los datos o intenta más tarde.");
                }
            });

            GoToLoginCommand = new RelayCommand(() =>
            {
                OnCancelRegister?.Invoke();
            });
        }
    }
}
