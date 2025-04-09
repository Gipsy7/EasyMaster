using EasyMaster.Application;
using EasyMaster.Model.RPG;
using EasyMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemService _personagemService;

        public PersonagemController(IPersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonagemViewModel>> Get()
        {
            return await _personagemService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PersonagemViewModel> Get(int id)
        {
            return await _personagemService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonagemViewModel personagem)
        {
            await _personagemService.AddAsync(personagem);
            return CreatedAtAction(nameof(Get), new { id = personagem.IdPersonagem }, personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PersonagemViewModel personagem)
        {
            if (id != personagem.IdPersonagem)
            {
                return BadRequest();
            }

            await _personagemService.UpdateAsync(personagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personagemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
