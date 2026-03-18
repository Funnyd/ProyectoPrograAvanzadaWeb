using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpleadoController : ControllerBase, IEmpleadoController
    {

        private IEmpleadoFlujo _empleadoFlujo;
        private ILogger<EmpleadoController> _logger;



        #region "Operaciones"
        public EmpleadoController(IEmpleadoFlujo empleadoFlujo, ILogger<EmpleadoController> logger)
        {
            _empleadoFlujo = empleadoFlujo;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Agregar([FromBody] EmpleadoRequest empleado)
        {
            var resultado = await _empleadoFlujo.Agregar(empleado);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] EmpleadoRequest empleado)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Empleado no existe");
            var resultado = await _empleadoFlujo.Editar(Id, empleado);
            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarExistencia(Id))
                return NotFound("Empleado no existe");
            var resultado = await _empleadoFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        [Authorize (Roles = "Administrador")]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _empleadoFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _empleadoFlujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion

        #region "Helpers"
        private async Task<bool> VerificarExistencia(Guid Id)
        {
            var Validacion = false;
            var Existe = await _empleadoFlujo.Obtener(Id);
            if (Existe != null)
                return Validacion = true;
            return Validacion;
        }
        #endregion

    }
}
