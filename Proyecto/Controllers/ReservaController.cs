using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase, IReservaController
    {

        private IReservaFlujo _reservaFlujo;
        private ILogger<ReservaController> _logger;



        #region "Operaciones"
        public ReservaController(IReservaFlujo reservaFlujo, ILogger<ReservaController> logger)
        {
            _reservaFlujo = reservaFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ReservaRequest reserva)
        {
            var resultado = await _reservaFlujo.Agregar(reserva);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] ReservaRequest reserva)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Reserva no existe");
            var resultado = await _reservaFlujo.Editar(Id, reserva);
            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Reserva no existe");
            var resultado = await _reservaFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _reservaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _reservaFlujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion

        #region "Helpers"
        private async Task<bool> VerificarExistencia(Guid Id)
        {
            var Validacion = false;
            var Existe = await _reservaFlujo.Obtener(Id);
            if (Existe != null)
                return Validacion = true;
            return Validacion;
        }
        #endregion

    }
}
