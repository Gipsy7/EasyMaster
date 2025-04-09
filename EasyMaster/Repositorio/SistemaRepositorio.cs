using EasyMaster.Model.RPG;
using Microsoft.EntityFrameworkCore;

namespace EasyMaster.Repositorio
{
    public class SistemaRepositorio : ISistemaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public SistemaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sistema>> GetAllAsync()
        {
            return await _context.Sistemas.ToListAsync();
        }

        public async Task<Sistema> GetByIdAsync(int id)
        {
            return await _context.Sistemas.FindAsync(id);
        }

        public async Task AddAsync(Sistema sistema)
        {
            await _context.Sistemas.AddAsync(sistema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sistema sistema)
        {
            _context.Sistemas.Update(sistema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sistema = await _context.Sistemas.FindAsync(id);
            if (sistema != null)
            {
                _context.Sistemas.Remove(sistema);
                await _context.SaveChangesAsync();
            }
        }
    }
}
