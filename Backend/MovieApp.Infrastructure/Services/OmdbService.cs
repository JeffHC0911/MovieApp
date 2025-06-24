using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MovieApp.Application.DTOs;

namespace MovieApp.Infrastructure.Services
{
    public class OmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OmdbService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["Omdb:ApiKey"] ?? throw new Exception("OMDb API key no configurada");
        }

        public async Task<List<MovieDto>> SearchByTitleAsync(string title)
        {
            var url = $"https://www.omdbapi.com/?apikey={_apiKey}&s={Uri.EscapeDataString(title)}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return new List<MovieDto>();

            var json = await response.Content.ReadAsStringAsync();

            var omdbResult = JsonSerializer.Deserialize<OmdbSearchResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (omdbResult == null || omdbResult.Response != "True")
                return new List<MovieDto>();

            return omdbResult.Search.Select(m => new MovieDto
            {
                Title = m.Title,
                Year = m.Year,
                Poster = m.Poster
            }).ToList();
        }
    }
}
