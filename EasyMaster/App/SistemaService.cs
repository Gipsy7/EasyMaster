using EasyMaster.Model.RPG;
using EasyMaster.Repositorio;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepositorio _sistemaRepositorio;

        public SistemaService(ISistemaRepositorio sistemaRepositorio)
        {
            _sistemaRepositorio = sistemaRepositorio;
        }

        public async Task<IEnumerable<SistemaViewModel>> GetAllAsync()
        {
            var sistemas = await _sistemaRepositorio.GetAllAsync();
            return sistemas.Select(s => new SistemaViewModel
            {
                IdSistema = s.IdSistema,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Modulos = s.Modulos?.Select(m => new ModuloViewModel
                {
                    IdModulo = m.IdModulo,
                    Nome = m.Nome,
                    Tipo = m.Tipo,
                    Componentes = m.Componentes?.Select(c => new ComponenteViewModel
                    {
                        IdComponente = c.IdComponente,
                        Nome = c.Nome,
                        Descricao = c.Descricao,
                        Valor = c.valor
                    }).ToList()
                }).ToList(),
                Personagens = s.Personagens?.Select(p => new PersonagemViewModel
                {
                    IdPersonagem = p.IdPersonagem,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Lore = p.Lore
                }).ToList()
            });
        }

        public async Task<SistemaViewModel> GetByIdAsync(int id)
        {
            var sistema = await _sistemaRepositorio.GetByIdAsync(id);
            if (sistema == null) return null;

            return new SistemaViewModel
            {
                IdSistema = sistema.IdSistema,
                Nome = sistema.Nome,
                Descricao = sistema.Descricao,
                Modulos = sistema.Modulos.Select(m => new ModuloViewModel
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
                    }).ToList()
                }).ToList(),
                Personagens = sistema.Personagens.Select(p => new PersonagemViewModel
                {
                    IdPersonagem = p.IdPersonagem,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Lore = p.Lore
                }).ToList()
            };
        }

        public async Task AddAsync(SistemaViewModel sistemaViewModel)
        {
            var sistema = new Sistema
            {
                Nome = sistemaViewModel.Nome,
                Descricao = sistemaViewModel.Descricao,
                Modulos = sistemaViewModel.Modulos.Select(m => new Modulo
                {
                    Nome = m.Nome,
                    Tipo = m.Tipo,
                    Componentes = m.Componentes.Select(c => new Componente
                    {
                        Nome = c.Nome,
                        Descricao = c.Descricao,
                        valor = c.Valor
                    }).ToList()
                }).ToList(),
                Personagens = sistemaViewModel.Personagens.Select(p => new Personagem
                {
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Lore = p.Lore
                }).ToList()
            };

            await _sistemaRepositorio.AddAsync(sistema);
        }

        public async Task UpdateAsync(SistemaViewModel sistemaViewModel)
        {
            var sistema = await _sistemaRepositorio.GetByIdAsync(sistemaViewModel.IdSistema);
            if (sistema == null) return;

            sistema.Nome = sistemaViewModel.Nome;
            sistema.Descricao = sistemaViewModel.Descricao;
            // Atualizar Modulos e Personagens conforme necessário

            await _sistemaRepositorio.UpdateAsync(sistema);
        }

        public async Task DeleteAsync(int id)
        {
            await _sistemaRepositorio.DeleteAsync(id);
        }
    }
}
