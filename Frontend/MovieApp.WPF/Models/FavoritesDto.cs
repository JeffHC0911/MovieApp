using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApp.WPF.Models
{
    public class FavoritesDto
    {
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        
        [JsonPropertyName("posterUrl")]
        public string Poster { get; set; } = string.Empty;
    }
}
