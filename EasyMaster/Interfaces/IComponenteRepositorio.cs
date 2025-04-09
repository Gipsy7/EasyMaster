using EasyMaster.Model.RPG;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Repositorio
{
    public interface IComponenteRepositorio
    {
        Task<IEnumerable<Componente>> GetAllAsync();
        Task<Componente> GetByIdAsync(int id);
        Task AddAsync(Componente componente);
        Task UpdateAsync(Componente componente);
        Task DeleteAsync(int id);
    }
}
