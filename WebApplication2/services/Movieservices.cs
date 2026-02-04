using Microsoft.EntityFrameworkCore;
using WebApplication2.models;

namespace WebApplication2.services


{

    public class Movieservices : Imovieservice
    {

        private readonly Applicationdbcontext _context;
        public Movieservices(Applicationdbcontext context) => _context = context;
        public async Task<Movie> addmovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task<IEnumerable<Movie>> getallmovie()
        {
            return await _context.Movies.Include(e => e.gener).ToListAsync();
        }

       

        public async Task<Movie> getbyidmoiv(int id)
        {
            return await _context.Movies.Include(e => e.gener).SingleOrDefaultAsync(x => x.generId == id);
        }

        public Movie update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }

       
    }
}
