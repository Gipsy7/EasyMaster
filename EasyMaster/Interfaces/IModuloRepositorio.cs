using EasyMaster.Model.RPG;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Repositorio
{
    public interface IModuloRepositorio
    {
        Task<IEnumerable<Modulo>> GetAllAsync();
        Task<Modulo> GetByIdAsync(int id);
        Task AddAsync(Modulo modulo);
        Task UpdateAsync(Modulo modulo);
        Task DeleteAsync(int id);
    }
}
