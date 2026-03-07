using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IPedidoController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(PedidoRequest pedido);
        Task<IActionResult> Editar(Guid Id, PedidoRequest pedido);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
