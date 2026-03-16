using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : Controller, IPromocionController
    {
        private IPromocionFlujo _promocionFlujo;

        public PromocionController(IPromocionFlujo promocionFlujo)
        {
            _promocionFlujo = promocionFlujo;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] PromocionRequest promocion)
        {
            var resultado = await _promocionFlujo.Agregar(promocion);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, [FromBody] PromocionRequest promocion)
        {
            var resultado = await _promocionFlujo.Editar(Id, promocion);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            await _promocionFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _promocionFlujo.Obtener();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _promocionFlujo.Obtener(Id);
            return Ok(resultado);
        }
    }
}