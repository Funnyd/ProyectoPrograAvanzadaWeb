using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase, IMenuController
    {

        private IMenuFlujo _menuFlujo;
        private ILogger<MenuController> _logger;



        public MenuController(IMenuFlujo menuFlujo, ILogger<MenuController> logger)
        {
            _menuFlujo = menuFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] MenuRequest menu)
        {
            var resultado = await _menuFlujo.Agregar(menu);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] Guid idRestaurante, [FromQuery] Guid idProducto, [FromBody] MenuRequest menu)
        {

            var resultado = await _menuFlujo.Editar(idRestaurante, idProducto, menu);
            return Ok(resultado);
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromQuery] Guid idRestaurante, [FromQuery] Guid idProducto)
        {

            var resultado = await _menuFlujo.Eliminar(idRestaurante, idProducto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _menuFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }


    }
}
