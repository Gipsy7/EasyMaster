using EasyMaster.Model.RPG;
using EasyMaster.Repositorio;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepositorio _moduloRepositorio;

        public ModuloService(IModuloRepositorio moduloRepositorio)
        {
            _moduloRepositorio = moduloRepositorio;
        }

        public async Task<IEnumerable<ModuloViewModel>> GetAllAsync()
        {
            var modulos = await _moduloRepositorio.GetAllAsync();
            return modulos.Select(m => new ModuloViewModel
            {
                IdModulo = m.IdModulo,
                Nome = m.Nome,
                Tipo = m.Tipo,
                Componentes = m.Componentes.Select(c => new ComponenteViewModel
                {
                    IdComponente = c.IdComponente,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Valor = c.valor
                }).ToList(),
                IdSistema = m.IdSistema
            });
        }

        public async Task<ModuloViewModel> GetByIdAsync(int id)
        {
            var modulo = await _moduloRepositorio.GetByIdAsync(id);
            if (modulo == null) return null;

            return new ModuloViewModel
            {
                IdModulo = modulo.IdModulo,
                Nome = modulo.Nome,
                Tipo = modulo.Tipo,
                Componentes = modulo.Componentes.Select(c => new ComponenteViewModel
                {
                    IdComponente = c.IdComponente,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Valor = c.valor
                }).ToList(),
                IdSistema = modulo.IdSistema
            };
        }

        public async Task AddAsync(ModuloViewModel moduloViewModel)
        {
            var modulo = new Modulo
            {
                Nome = moduloViewModel.Nome,
                Tipo = moduloViewModel.Tipo,
                Componentes = moduloViewModel.Componentes.Select(c => new Componente
                {
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    valor = c.Valor
                }).ToList(),
                IdSistema = moduloViewModel.IdSistema
            };

            await _moduloRepositorio.AddAsync(modulo);
        }

        public async Task UpdateAsync(ModuloViewModel moduloViewModel)
        {
            var modulo = await _moduloRepositorio.GetByIdAsync(moduloViewModel.IdModulo);
            if (modulo == null) return;

            modulo.Nome = moduloViewModel.Nome;
            modulo.Tipo = moduloViewModel.Tipo;
            // Atualizar Componentes conforme necessário

            await _moduloRepositorio.UpdateAsync(modulo);
        }

        public async Task DeleteAsync(int id)
        {
            await _moduloRepositorio.DeleteAsync(id);
        }
    }
}
