using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public interface ISistemaService
    {
        Task<IEnumerable<SistemaViewModel>> GetAllAsync();
        Task<SistemaViewModel> GetByIdAsync(int id);
        Task AddAsync(SistemaViewModel sistema);
        Task UpdateAsync(SistemaViewModel sistema);
        Task DeleteAsync(int id);
    }
}
