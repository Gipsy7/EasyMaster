using EasyMaster.Model.RPG;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public interface IModuloService
    {
        Task<IEnumerable<ModuloViewModel>> GetAllAsync();
        Task<ModuloViewModel> GetByIdAsync(int id);
        Task AddAsync(ModuloViewModel modulo);
        Task UpdateAsync(ModuloViewModel modulo);
        Task DeleteAsync(int id);
    }
}
