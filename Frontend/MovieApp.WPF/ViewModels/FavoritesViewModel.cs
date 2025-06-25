using MovieApp.WPF.Models;
using MovieApp.WPF.Services;
using MovieApp.WPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MovieApp.WPF.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<MovieDto> FavoriteMovies { get; } = new();

        public FavoritesViewModel()
        {
            _ = LoadFavoritesAsync();
        }

        private async Task LoadFavoritesAsync()
        {
            try
            {
                var movies = await MovieService.GetFavoritesAsync();
                FavoriteMovies.Clear();
                foreach (var movie in movies)
                    FavoriteMovies.Add(movie);
            }
            catch (Exception ex)
            {
                // opcional: mostrar error
                Console.WriteLine(ex.Message);
            }
        }
    }
}
