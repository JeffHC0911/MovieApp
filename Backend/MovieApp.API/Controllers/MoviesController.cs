using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Services;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly OmdbService _omdb;

        public MoviesController(OmdbService omdb)
        {
            _omdb = omdb;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("El título es requerido");

            var result = await _omdb.SearchByTitleAsync(title);
            if (result == null)
                return StatusCode(500, "Error al consultar OMDb");

            return Ok(result);
        }
    }
}
