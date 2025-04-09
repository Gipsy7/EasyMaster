using EasyMaster.Model.RPG;
using EasyMaster.Repositorio;
using EasyMaster.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Application
{
    public class PersonagemService : IPersonagemService
    {
        private readonly IPersonagemRepositorio _personagemRepositorio;

        public PersonagemService(IPersonagemRepositorio personagemRepositorio)
        {
            _personagemRepositorio = personagemRepositorio;
        }

        public async Task<IEnumerable<PersonagemViewModel>> GetAllAsync()
        {
            var personagens = await _personagemRepositorio.GetAllAsync();
            return personagens.Select(p => new PersonagemViewModel
            {
                IdPersonagem = p.IdPersonagem,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Lore = p.Lore,
                IdSistema = p.IdSistema
            });
        }

        public async Task<PersonagemViewModel> GetByIdAsync(int id)
        {
            var personagem = await _personagemRepositorio.GetByIdAsync(id);
            if (personagem == null) return null;

            return new PersonagemViewModel
            {
                IdPersonagem = personagem.IdPersonagem,
                Nome = personagem.Nome,
                Descricao = personagem.Descricao,
                Lore = personagem.Lore,
                IdSistema = personagem.IdSistema
            };
        }

        public async Task AddAsync(PersonagemViewModel personagemViewModel)
        {
            var personagem = new Personagem
            {
                Nome = personagemViewModel.Nome,
                Descricao = personagemViewModel.Descricao,
                Lore = personagemViewModel.Lore,
                IdSistema = personagemViewModel.IdSistema
            };

            await _personagemRepositorio.AddAsync(personagem);
        }

        public async Task UpdateAsync(PersonagemViewModel personagemViewModel)
        {
            var personagem = await _personagemRepositorio.GetByIdAsync(personagemViewModel.IdPersonagem);
            if (personagem == null) return;

            personagem.Nome = personagemViewModel.Nome;
            personagem.Descricao = personagemViewModel.Descricao;
            personagem.Lore = personagemViewModel.Lore;
            // Atualizar outros campos conforme necessário

            await _personagemRepositorio.UpdateAsync(personagem);
        }

        public async Task DeleteAsync(int id)
        {
            await _personagemRepositorio.DeleteAsync(id);
        }
    }
}
