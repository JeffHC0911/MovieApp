using MovieApp.WPF.Services;
using MovieApp.WPF.ViewModels.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MovieApp.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel? _currentViewModel;
        public BaseViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        // 👇 Propiedades para el Header
        public ICommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }
        public bool IsLoggedIn => AuthService.IsLoggedIn;

        public MainViewModel()
        {
            // Comandos disponibles globalmente
            LoginCommand = new RelayCommand(ShowLoginView);
            LogoutCommand = new RelayCommand(() =>
            {
                AuthService.Logout();
                OnPropertyChanged(nameof(IsLoggedIn));
                //ShowSearchView(); // Vuelve a búsqueda tras logout
            });

            ShowSearchView(); // Vista inicial
        }

        public void ShowSearchView()
        {
            var vm = new SearchViewModel();
            vm.OnLoginRequested += ShowLoginView;
            vm.OnLogout += ShowSearchView;
            CurrentViewModel = vm;
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public void ShowLoginView()
        {
            var loginVM = new LoginViewModel();
            loginVM.OnLoginSuccess += ShowSearchView;
            CurrentViewModel = loginVM;
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        // Opcional: si quieres incluir registro después
        /*
        public void ShowRegisterView()
        {
            var vm = new RegisterViewModel();
            vm.OnRegisterSuccess += ShowLoginView;
            vm.OnCancelRegister += ShowLoginView;
            CurrentViewModel = vm;
        }
        */
    }
}
