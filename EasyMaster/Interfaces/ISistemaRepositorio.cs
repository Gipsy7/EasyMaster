using EasyMaster.Model.RPG;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Repositorio
{
    public interface ISistemaRepositorio
    {
        Task<IEnumerable<Sistema>> GetAllAsync();
        Task<Sistema> GetByIdAsync(int id);
        Task AddAsync(Sistema sistema);
        Task UpdateAsync(Sistema sistema);
        Task DeleteAsync(int id);
    }
}
