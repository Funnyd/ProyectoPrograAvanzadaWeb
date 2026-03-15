using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IMenuController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Agregar(MenuRequest menu);
        Task<IActionResult> Editar(Guid idRestaurante, Guid idProducto, MenuRequest menu);
        Task<IActionResult> Eliminar(Guid idRestaurante, Guid idProducto);

    }
}
