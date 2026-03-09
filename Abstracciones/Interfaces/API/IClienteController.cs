using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IClienteController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(ClienteRequest cliente);
        Task<IActionResult> Editar(Guid Id, ClienteRequest cliente);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
