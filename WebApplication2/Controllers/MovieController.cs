using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dto;
using WebApplication2.models;
using WebApplication2.services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly Imovieservice _movieservice;
        private readonly IGenerservices _generseverice;
        public MovieController(Imovieservice movieservice, IGenerservices generseverice)
        {
            _movieservice = movieservice;
            _generseverice = generseverice;
        }

        private new List<string> allowedExtention = new List<string> { ".jpg", ".png" };
        private long allowedsize = 1048576;

        [HttpPost]
        public async Task<IActionResult> add([FromForm]Moviedt dto)
        {
            if (! allowedExtention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            return BadRequest("the allowed extention is .jpg and .png");
            if (dto.Poster.Length > allowedsize)
                return BadRequest("max size is 1mb");

            var isvalid = await _generseverice.isvalid(dto.generId);

            if (!isvalid)
                return BadRequest("the gener id not found");
            using var datastream=new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);

            var move = new Movie
            {
                Id = dto.Id,
                Title = dto.Title,
                Rate = dto.Rate,
                Poster = datastream.ToArray(),
                generId = dto.generId,
                year = dto.year,
                storeline = dto.storeline

            };
            await _movieservice.addmovie(move); 
            return Ok(move);
        }


        [HttpGet]
        public async Task <IActionResult> getallmovies()
        {
            var movies = await _movieservice.getallmovie();

            return Ok(movies);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getmovie(int id)
        {
            var movies = await _movieservice.getbyidmoiv(id);
            if (movies == null) return BadRequest("empty ");
            return Ok(movies);
        }


        //[HttpGet("generid")]

        //public async Task<IActionResult> Getmoviebygener(byte id)
        //{
        //    var movies = await _context.Movies.Include(e => e.gener).SingleOrDefaultAsync(x => x.generId == id);
        //    if (movies == null) return BadRequest("empty ");
        //    return Ok(movies);
        //}


        [HttpDelete("{id}")]

        public async Task<IActionResult> deletemovie(int id)
        {
            var movies = await _movieservice.getbyidmoiv(id);
            if (movies == null) return BadRequest("empty ");
            _movieservice.delete(movies);
            return Ok(movies);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> update(int id,Moviedt dto)
        {
            var movies = await _movieservice.getbyidmoiv(id);
            if (movies == null) return BadRequest("empty ");

            var isvalid = await _generseverice.isvalid(dto.generId);
            if (!isvalid)
                return BadRequest("the gener id not found");
            if (movies.Poster != null)
            {
                if (!allowedExtention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("the allowed extention is .jpg and .png");
                if (dto.Poster.Length > allowedsize)
                    return BadRequest("max size is 1mb");
                using var datastream = new MemoryStream();
                await dto.Poster.CopyToAsync(datastream);
                movies.Poster = datastream.ToArray();

            }

            movies.Title = dto.Title;
            movies.storeline = dto.storeline;
            movies.year=dto.year;
            movies.generId = dto.generId;
            movies.Rate = dto.Rate;
            

           _movieservice.update(movies);    
            return Ok(movies);
        }



    }
}
