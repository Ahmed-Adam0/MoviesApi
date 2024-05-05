using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Servies;
using System.Runtime.CompilerServices;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private List<string> _Ellowextantion=new List<string> { ".jpg", ".png" };
        private long _maxAllowpostersize=1048576;

        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService moviesService, IGenresService genresService, IMapper mapper)
        {
            _moviesService = moviesService;
            _genresService = genresService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllasync()
        {

            var movies = await _moviesService.GetallMoviesAsync();
            var data=_mapper.Map<IEnumerable<MoviesDetaiDto>>(movies);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id )
        {
            var movie = await _moviesService.getbyid(id);
            if(movie==null)
                return NotFound();
            var dto = _mapper.Map<MoviesDetaiDto>(movie);
            return Ok(dto);
        }
        //[HttpGet("getbygenreid")]
        //public async Task<IActionResult> getbygenreid(int genreid)
        //{
        //    var movies = await _context.movies.Where(m=>m.GenreId==genreid).OrderByDescending(o => o.Rate).Include(m => m.Genre).Select(m => new MoviesDetaiDto
        //    {
        //        Id = m.Id,
        //        GenreId = m.GenreId,
        //        Poster = m.Poster,
        //        Rate = m.Rate,
        //        Storeline = m.Storeline,
        //        Title = m.Title,
        //        Year = m.Year,
        //    })
        //    .ToListAsync();
        //    return Ok(movies);
        //}
        [HttpPost]
        public async Task<IActionResult> postasync([FromForm] MoviesDto dto)
        {
            if (dto.Poster == null)
                return BadRequest("poster is requirment");
            if (!_Ellowextantion.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("only .jpg or .png in poster");
            if (dto.Poster.Length > _maxAllowpostersize)
                return BadRequest("the length shoud be <1MB:");

            var isvalaidid = await _genresService.isvalidgenre(dto.GenreId);
            if (!isvalaidid)
                return BadRequest("id is not found");

            using var datastream=new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);


            var movie = _mapper.Map<Movie>(dto);
            movie.Poster=datastream.ToArray();
            _moviesService.postasync(movie);
            return Ok(movie);    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id, [FromForm] MoviesDto dto )
        {
            var movie=await _moviesService.getbyid(id);
            if (movie == null)
                return BadRequest($"not found id ={id}");
            var isvalaidid = await _genresService.isvalidgenre(dto.GenreId);
            if (!isvalaidid) return BadRequest("you genreid not corect");

            if(movie.Poster !=null)
            {
                if (!_Ellowextantion.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("only .jpg or .png in poster");
                if (dto.Poster.Length > _maxAllowpostersize)
                    return BadRequest("the length shoud be <1MB:");
                using var datastreem = new MemoryStream();
                await dto.Poster.CopyToAsync(datastreem);
                movie.Poster = datastreem.ToArray();
            }
            movie.Title = dto.Title;
            movie.Storeline = dto.Storeline;
            movie.Year = dto.Year;  
            movie.Rate = dto.Rate;
               
            _moviesService.update(movie);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletasync(int id)
        {
            var movie = await _moviesService.getbyid(id);
            if (movie == null) 
                return NotFound($"not found movie id ={id}");
            _moviesService.delete(movie);
            return Ok(movie);
        }
    }
}
