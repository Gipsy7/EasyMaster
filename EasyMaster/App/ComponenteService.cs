using EasyMaster.Model.RPG;
using EasyMaster.Repositorio;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public class ComponenteService : IComponenteService
    {
        private readonly IComponenteRepositorio _componenteRepositorio;

        public ComponenteService(IComponenteRepositorio componenteRepositorio)
        {
            _componenteRepositorio = componenteRepositorio;
        }

        public async Task<IEnumerable<ComponenteViewModel>> GetAllAsync()
        {
            var componentes = await _componenteRepositorio.GetAllAsync();
            return componentes.Select(c => new ComponenteViewModel
            {
                IdComponente = c.IdComponente,
                Nome = c.Nome,
                Descricao = c.Descricao,
                Valor = c.valor,
                IdModulo = c.IdModulo
            });
        }

        public async Task<ComponenteViewModel> GetByIdAsync(int id)
        {
            var componente = await _componenteRepositorio.GetByIdAsync(id);
            if (componente == null) return null;

            return new ComponenteViewModel
            {
                IdComponente = componente.IdComponente,
                Nome = componente.Nome,
                Descricao = componente.Descricao,
                Valor = componente.valor,
                IdModulo = componente.IdModulo
            };
        }

        public async Task AddAsync(ComponenteViewModel componenteViewModel)
        {
            var componente = new Componente
            {
                Nome = componenteViewModel.Nome,
                Descricao = componenteViewModel.Descricao,
                valor = componenteViewModel.Valor,
                IdModulo = componenteViewModel.IdModulo
            };

            await _componenteRepositorio.AddAsync(componente);
        }

        public async Task UpdateAsync(ComponenteViewModel componenteViewModel)
        {
            var componente = await _componenteRepositorio.GetByIdAsync(componenteViewModel.IdComponente);
            if (componente == null) return;

            componente.Nome = componenteViewModel.Nome;
            componente.Descricao = componenteViewModel.Descricao;
            componente.valor = componenteViewModel.Valor;
            // Atualizar outros campos conforme necessário

            await _componenteRepositorio.UpdateAsync(componente);
        }

        public async Task DeleteAsync(int id)
        {
            await _componenteRepositorio.DeleteAsync(id);
        }
    }
}
