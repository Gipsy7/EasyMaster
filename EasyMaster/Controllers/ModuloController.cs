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
    public class ModuloController : ControllerBase
    {
        private readonly IModuloService _moduloService;

        public ModuloController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        [HttpGet]
        public async Task<IEnumerable<ModuloViewModel>> Get()
        {
            return await _moduloService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ModuloViewModel> Get(int id)
        {
            return await _moduloService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ModuloViewModel modulo)
        {
            await _moduloService.AddAsync(modulo);
            return CreatedAtAction(nameof(Get), new { id = modulo.IdModulo }, modulo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModuloViewModel modulo)
        {
            if (id != modulo.IdModulo)
            {
                return BadRequest();
            }

            await _moduloService.UpdateAsync(modulo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moduloService.DeleteAsync(id);
            return NoContent();
        }
    }
}
