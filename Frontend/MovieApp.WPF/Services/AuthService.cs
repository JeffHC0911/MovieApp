using MovieApp.WPF.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MovieApp.WPF.Services
{
    public static class AuthService
    {
        public static string? Token { get; private set; }

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(Token);


        private static readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7293") // Cambia al puerto de tu API
        };

        public static async Task<bool> LoginAsync(string email, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", new LoginDto
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            Token = result?.Token;

            if (Token != null)
                _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            return true;
        }

        public static async Task<bool> RegisterAsync(string email, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/register", new UserRegisterDto
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error del servidor: {errorMsg}");
                return false;
            }

            return true;
        }

        public static void Logout()
        {
            Token = null;
            _http.DefaultRequestHeaders.Authorization = null;
        }


    }
}
