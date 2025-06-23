using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Infrastructure.Data;
using System.Security.Claims;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoritesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] AddFavoriteDto dto)
        {
            var email = User.Identity?.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return Unauthorized();

            var favorite = new FavoriteMovie
            {
                Title = dto.Title,
                Year = dto.Year,
                PosterUrl = dto.PosterUrl,
                UserId = user.Id
            };

            _context.FavoriteMovies.Add(favorite);
            await _context.SaveChangesAsync();

            return Ok("Película guardada como favorita");
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var email = User.Identity?.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return Unauthorized();

            var favorites = await _context.FavoriteMovies
                .Where(f => f.UserId == user.Id)
                .ToListAsync();

            return Ok(favorites);
        }
    }

    public class AddFavoriteDto
    {
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
    }

}
