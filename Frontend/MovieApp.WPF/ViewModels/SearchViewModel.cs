using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MovieApp.WPF.Models;
using MovieApp.WPF.Services;
using MovieApp.WPF.ViewModels.Base;

namespace MovieApp.WPF.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private string _searchTerm = string.Empty;
        public string SearchTerm
        {
            get => _searchTerm;
            set { _searchTerm = value; OnPropertyChanged(); }
        }

        public ObservableCollection<MovieDto> SearchResults { get; set; } = new();

        public ICommand SearchCommand { get; }
        public ICommand AddFavoriteCommand { get; }

        public event Action? OnLoginRequested;
        public event Action? OnLogout;

        public SearchViewModel()
        {
            SearchCommand = new RelayCommand(async () =>
            {
                try
                {
                    var results = await MovieService.SearchMoviesAsync(SearchTerm);
                    SearchResults.Clear();
                    foreach (var movie in results)
                        SearchResults.Add(movie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar películas: " + ex.Message);
                }
            });

            AddFavoriteCommand = new RelayCommand<MovieDto>(async (movie) =>
            {
                if (!AuthService.IsLoggedIn)
                {
                    MessageBox.Show("Debes iniciar sesión para agregar a favoritos.");
                    //OnLoginRequested?.Invoke();
                    return;
                }

                try
                {
                    var success = await MovieService.AddFavoriteAsync(movie);
                    MessageBox.Show("Agregada a favoritos.");
                    if (!success)
                        MessageBox.Show("No se pudo agregar a favoritos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar a favoritos: " + ex.Message);
                }
            });
        }
    }

}
