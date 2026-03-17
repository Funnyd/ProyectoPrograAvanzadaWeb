using Abstracciones.API;
using Abstracciones.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller, IUsuarioController
    {
        private IUsuarioFlujo _usuarioFlujo;

        public UsuarioController(IUsuarioFlujo usuarioFlujo)
        {
            _usuarioFlujo = usuarioFlujo;
        }

        [Authorize (Roles = "Cliente")]
        [HttpPost("ObtenerInformacionUsuario")]
        public async Task<IActionResult> ObtenerUsuario([FromBody] LoginBase login)
        {
            return Ok( await _usuarioFlujo.ObtenerUsuario(login));
        }

        [AllowAnonymous]
        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> PostAsync([FromBody] ClienteCompleto clienteCompleto)
        {
            var resultado=await _usuarioFlujo.CrearUsuario(clienteCompleto);
            return CreatedAtAction(nameof(ObtenerUsuario),null, resultado);
        }




    }
}
