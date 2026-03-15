using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase, IDetalleController
    {

        private IDetalleFlujo _detalleFlujo;
        private ILogger<DetalleController> _logger;



        public DetalleController(IDetalleFlujo detalleFlujo, ILogger<DetalleController> logger)
        {
            _detalleFlujo = detalleFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] DetalleRequest detalle)
        {
            var resultado = await _detalleFlujo.Agregar(detalle);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] Guid idPedido, [FromQuery] Guid idProducto, [FromBody] DetalleRequest detalle)
        {

            var resultado = await _detalleFlujo.Editar(idPedido, idProducto, detalle);
            return Ok(resultado);
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromQuery] Guid idPedido, [FromQuery] Guid idProducto)
        {

            var resultado = await _detalleFlujo.Eliminar(idPedido, idProducto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _detalleFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }


    }
}
