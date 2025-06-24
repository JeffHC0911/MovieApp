using MovieApp.WPF.ViewModels.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MovieApp.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel? _currentViewModel;
        public BaseViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            ShowSearchView();
        }

        public void ShowSearchView()
        {
            var vm = new SearchViewModel();
            //vm.OnLoginSuccess += ShowSearchView;
            //vm.OnRegisterRequested += ShowRegisterView;
            CurrentViewModel = vm;
        }

        /*public void ShowRegisterView()
        {
            var vm = new RegisterViewModel();
            vm.OnRegisterSuccess += ShowLoginView;
            vm.OnCancelRegister += ShowLoginView;
            CurrentViewModel = vm;
        }
        */

        /*public void ShowSearchView()
        {
            CurrentViewModel = new SearchViewModel();
        }
        */
    }
}
