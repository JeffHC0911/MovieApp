using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MovieApp.WPF.Models;

namespace MovieApp.WPF.Services
{
    public static class MovieService
    {
        private static readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7293") // Reemplaza si usas otro puerto
        };

        static MovieService()
        {
            if (!string.IsNullOrEmpty(AuthService.Token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Token);
            }
        }

        public static async Task<List<MovieDto>> SearchMoviesAsync(string title)
        {
            if (!string.IsNullOrWhiteSpace(AuthService.Token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Token);
            }

            var response = await _http.GetAsync($"/api/movies/search?title={Uri.EscapeDataString(title)}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al buscar películas");

            var movies = await response.Content.ReadFromJsonAsync<List<MovieDto>>();
            return movies ?? new List<MovieDto>();
        }

        public static async Task<bool> AddFavoriteAsync(MovieDto movie)
        {
            if (!string.IsNullOrWhiteSpace(AuthService.Token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Token);
            }

            var payload = new
            {
                title = movie.Title,
                year = movie.Year,
                posterUrl = movie.Poster
            };

            var response = await _http.PostAsJsonAsync("/api/favorites", payload);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<MovieDto>> GetFavoritesAsync()
        {
            if (!string.IsNullOrWhiteSpace(AuthService.Token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Token);
            }

            var response = await _http.GetAsync("/api/favorites");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al obtener películas favoritas");

            var favorites = await response.Content.ReadFromJsonAsync<List<MovieDto>>();
            return favorites ?? new List<MovieDto>();
        }

    }
}
