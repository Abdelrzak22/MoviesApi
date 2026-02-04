using Microsoft.EntityFrameworkCore;
using WebApplication2.models;

namespace WebApplication2.dbcontext
{
    public class Applicationdbcontext : DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options):base(options) { }

        public DbSet<Gener> Geners { get; set; }    
        public DbSet<Movie> Movies { get; set; }    
    }
}
