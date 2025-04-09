using EasyMaster.Model.RPG;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Repositorio
{
    public interface IPersonagemRepositorio
    {
        Task<IEnumerable<Personagem>> GetAllAsync();
        Task<Personagem> GetByIdAsync(int id);
        Task AddAsync(Personagem personagem);
        Task UpdateAsync(Personagem personagem);
        Task DeleteAsync(int id);
    }
}
