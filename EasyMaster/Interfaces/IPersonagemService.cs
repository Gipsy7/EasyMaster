using EasyMaster.Model.RPG;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public interface IPersonagemService
    {
        Task<IEnumerable<PersonagemViewModel>> GetAllAsync();
        Task<PersonagemViewModel> GetByIdAsync(int id);
        Task AddAsync(PersonagemViewModel personagem);
        Task UpdateAsync(PersonagemViewModel personagem);
        Task DeleteAsync(int id);
    }
}
