using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities
{
    public class FavoriteMovie
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

