using EasyMaster.Model.RPG;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public interface IComponenteService
    {
        Task<IEnumerable<ComponenteViewModel>> GetAllAsync();
        Task<ComponenteViewModel> GetByIdAsync(int id);
        Task AddAsync(ComponenteViewModel componente);
        Task UpdateAsync(ComponenteViewModel componente);
        Task DeleteAsync(int id);
    }
}
