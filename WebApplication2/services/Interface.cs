using WebApplication2.models;

namespace WebApplication2.services
{
    public interface IGenerservices
    {
        Task<IEnumerable<Gener>> getall();
        Task<Gener> update(Gener gener);    
        Task<Gener> delete(Gener gener);
        Task<Gener> add (Gener gener);
        Task<Gener> getbyid(byte id);
        Task<bool> isvalid(byte id);
    }
}
