using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IReservaController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(ReservaRequest reserva);
        Task<IActionResult> Editar(Guid Id, ReservaRequest reserva);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
