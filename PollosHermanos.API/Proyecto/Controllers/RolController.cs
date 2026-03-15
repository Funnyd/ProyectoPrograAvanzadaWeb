using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase, IRolController
    {
        private IRolFlujo _rolFlujo;
        private ILogger<RolController> _logger;

        public RolController(IRolFlujo rolFlujo, ILogger<RolController> logger)
        {
            _rolFlujo = rolFlujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _rolFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{rol}")] 
        public async Task<IActionResult> ObtenerRol([FromRoute] string rol) 
        {
            var resultado = await _rolFlujo.ObtenerRol(rol);
            return Ok(resultado);
        }

    }
}
