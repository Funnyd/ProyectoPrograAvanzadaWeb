using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IDetalleController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Agregar(DetalleRequest detalle);
        Task<IActionResult> Editar(Guid idPedido, Guid idProducto, DetalleRequest detalle);
        Task<IActionResult> Eliminar(Guid idPedido, Guid idProducto);

    }
}
