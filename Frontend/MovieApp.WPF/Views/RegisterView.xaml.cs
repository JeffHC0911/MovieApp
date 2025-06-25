using System.Windows.Controls;
using MovieApp.WPF.ViewModels;

namespace MovieApp.WPF.Views
{
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
                vm.Password = ((PasswordBox)sender).Password;
        }
    }
}
