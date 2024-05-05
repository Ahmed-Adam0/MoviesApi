using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Servies;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        //public GenresController(ApplicationDbContext context)
        //{
        //    _context = context; 
        //}
        //[HttpGet]
        //public async Task<IActionResult> Getallasync()
        //{
        //    var genres = await _context.genres.ToListAsync();
        //    return Ok(genres);
        //}
        private readonly IGenresService _genresService;
        public GenresController( IGenresService genresService)
        {
            _genresService = genresService;
        }
        [HttpGet]
        public async Task<IActionResult> getallasync()
        {
            var genre = await _genresService.Getall();
            return Ok (genre); 
        }
        [HttpPost]
        public async Task<IActionResult> Createasync(CreateGenresDto dto)
        {
            var genre = new Genre { Name = dto.name };
            await _genresService.add(genre);
            return Ok(genre);
        }
        [HttpPut( "{id}")]
        public async Task<IActionResult> updateasync(int id, [FromBody] CreateGenresDto dto)
        {
            var genre = await _genresService.Getbyid(id);
            if(genre==null)
                return NotFound($"not genre was found with id: {id}");
            genre.Name = dto.name;
            _genresService.update(genre);
            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> daleteasync(int id)
        {
            var genre = await _genresService.Getbyid(id);
            if(genre==null)
                return NotFound($"not found genre with this :{id}");
            _genresService.delete(genre);
            return Ok(genre);
        }
    }
} 