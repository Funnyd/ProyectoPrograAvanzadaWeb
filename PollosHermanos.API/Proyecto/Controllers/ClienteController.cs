using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase, IClienteController
    {

        private IClienteFlujo _clienteFlujo;
        private ILogger<ClienteController> _logger;



        #region "Operaciones"
        public ClienteController(IClienteFlujo clienteFlujo, ILogger<ClienteController> logger)
        {
            _clienteFlujo = clienteFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ClienteRequest cliente)
        {
            var resultado = await _clienteFlujo.Agregar(cliente);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] ClienteRequest cliente)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Cliente no existe");
            var resultado = await _clienteFlujo.Editar(Id, cliente);
            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Cliente no existe");
            var resultado = await _clienteFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _clienteFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _clienteFlujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion

        #region "Helpers"
        private async Task<bool> VerificarExistencia(Guid Id)
        {
            var Validacion = false;
            var Existe = await _clienteFlujo.Obtener(Id);
            if (Existe != null)
                return Validacion = true;
            return Validacion;
        }
        #endregion

    }
}
