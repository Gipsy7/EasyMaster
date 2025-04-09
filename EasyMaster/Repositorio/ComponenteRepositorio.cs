using EasyMaster.Model.RPG;
using Microsoft.EntityFrameworkCore;

namespace EasyMaster.Repositorio
{
    public class ComponenteRepositorio : IComponenteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ComponenteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Componente>> GetAllAsync()
        {
            return await _context.Componentes.ToListAsync();
        }

        public async Task<Componente> GetByIdAsync(int id)
        {
            return await _context.Componentes.FindAsync(id);
        }

        public async Task AddAsync(Componente componente)
        {
            await _context.Componentes.AddAsync(componente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Componente componente)
        {
            _context.Componentes.Update(componente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente != null)
            {
                _context.Componentes.Remove(componente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
