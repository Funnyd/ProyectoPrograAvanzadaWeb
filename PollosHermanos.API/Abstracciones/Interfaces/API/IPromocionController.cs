using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IPromocionController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(PromocionRequest promocion);
        Task<IActionResult> Editar(Guid Id, PromocionRequest promocion);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
