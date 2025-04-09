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
    public class ComponenteController : ControllerBase
    {
        private readonly IComponenteService _componenteService;

        public ComponenteController(IComponenteService componenteService)
        {
            _componenteService = componenteService;
        }

        [HttpGet]
        public async Task<IEnumerable<ComponenteViewModel>> Get()
        {
            return await _componenteService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ComponenteViewModel> Get(int id)
        {
            return await _componenteService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComponenteViewModel componente)
        {
            await _componenteService.AddAsync(componente);
            return CreatedAtAction(nameof(Get), new { id = componente.IdComponente }, componente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ComponenteViewModel componente)
        {
            if (id != componente.IdComponente)
            {
                return BadRequest();
            }

            await _componenteService.UpdateAsync(componente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _componenteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
