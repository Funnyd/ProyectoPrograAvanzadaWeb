using Abstracciones.Interfaces.API;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase, IUsuarioController
    {
        public Task<IActionResult> Agregar(UsuarioRequest usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Editar(Guid Id, UsuarioRequest usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Eliminar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View();
        }

        public Task<IActionResult> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Obtener(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
