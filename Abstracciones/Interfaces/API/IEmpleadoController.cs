using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IEmpleadoController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(EmpleadoRequest empleado);
        Task<IActionResult> Editar(Guid Id, EmpleadoRequest empleado);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
