using WebApplication2.models;

namespace WebApplication2.services
{
    public interface Imovieservice
    {
        Task<IEnumerable<Movie>> getallmovie();

        Task<Movie>getbyidmoiv(int id);
       

        Task<Movie> addmovie(Movie movie);
        Movie update(Movie movie);
        Movie delete(Movie movie);


    }
}
