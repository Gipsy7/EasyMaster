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
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaService _sistemaService;

        public SistemaController(ISistemaService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        [HttpGet]
        public async Task<IEnumerable<SistemaViewModel>> Get()
        {
            return await _sistemaService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SistemaViewModel> Get(int id)
        {
            return await _sistemaService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SistemaViewModel sistema)
        {
            await _sistemaService.AddAsync(sistema);
            return CreatedAtAction(nameof(Get), new { id = sistema.IdSistema }, sistema);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SistemaViewModel sistema)
        {
            if (id != sistema.IdSistema)
            {
                return BadRequest();
            }

            await _sistemaService.UpdateAsync(sistema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sistemaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
