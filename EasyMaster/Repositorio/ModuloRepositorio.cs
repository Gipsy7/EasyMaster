using EasyMaster.Model.RPG;
using Microsoft.EntityFrameworkCore;

namespace EasyMaster.Repositorio
{
    public class ModuloRepositorio : IModuloRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ModuloRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modulo>> GetAllAsync()
        {
            return await _context.Modulos.ToListAsync();
        }

        public async Task<Modulo> GetByIdAsync(int id)
        {
            return await _context.Modulos.FindAsync(id);
        }

        public async Task AddAsync(Modulo modulo)
        {
            await _context.Modulos.AddAsync(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Modulo modulo)
        {
            _context.Modulos.Update(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
