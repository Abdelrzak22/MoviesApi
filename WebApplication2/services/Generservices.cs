using Microsoft.EntityFrameworkCore;
using WebApplication2.models;

namespace WebApplication2.services
{
    
    public class Generservices : IGenerservices
    {

        private readonly Applicationdbcontext _context;
        public Generservices(Applicationdbcontext context) => _context = context;
        public async Task<Gener> add(Gener gener)
        {
            await _context.Geners.AddAsync(gener);
            _context.SaveChanges();
            return gener;

        }

        public async Task<Gener> delete(Gener gener)
        {
            _context.Remove(gener);
            _context.SaveChanges();
            return gener;
        }

        public async Task<IEnumerable<Gener>> getall()
        {
            return await _context.Geners.ToListAsync();
        }

        public async Task<Gener> getbyid(byte id)
        {
           return await _context.Geners.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<bool> isvalid(byte id)
        {
            return await _context.Geners.AnyAsync(g => g.Id == id);
        }

        public async Task<Gener> update(Gener gener)
        {
            _context.Update(gener);
            _context.SaveChanges();
            return gener;
        }
    }
}
