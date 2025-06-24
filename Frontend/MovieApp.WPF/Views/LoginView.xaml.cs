using System.Windows.Controls;
using MovieApp.WPF.ViewModels;

namespace MovieApp.WPF.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(); //Aquí se asigna el ViewModel
        }
    }
}
