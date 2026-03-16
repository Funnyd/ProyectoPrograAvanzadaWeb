using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase, IUsuarioController
    {

        private IUsuarioFlujo _usuarioFlujo;
        private ILogger<UsuarioController> _logger;



        #region "Operaciones"
        public UsuarioController(IUsuarioFlujo usuarioFlujo, ILogger<UsuarioController> logger)
        {
            _usuarioFlujo = usuarioFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] UsuarioRequest usuario)
        {
            var resultado = await _usuarioFlujo.Agregar(usuario);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] UsuarioRequest usuario)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Usuario no existe");
            var resultado = await _usuarioFlujo.Editar(Id, usuario);
            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Usuario no existe");
            var resultado = await _usuarioFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _usuarioFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _usuarioFlujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion

        #region "Helpers"
        private async Task<bool> VerificarExistencia(Guid Id)
        {
            var Validacion = false;
            var Existe = await _usuarioFlujo.Obtener(Id);
            if (Existe != null)
                return Validacion = true;
            return Validacion;
        }
        #endregion

    }
}
