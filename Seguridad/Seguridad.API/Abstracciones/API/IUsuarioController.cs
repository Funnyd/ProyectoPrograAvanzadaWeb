using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.API
{
    public interface IUsuarioController
    {
        Task<IActionResult> PostAsync([FromBody] ClienteCompleto clienteCompleto);
        Task<IActionResult> ObtenerUsuario([FromBody] LoginBase login);
    }
}
