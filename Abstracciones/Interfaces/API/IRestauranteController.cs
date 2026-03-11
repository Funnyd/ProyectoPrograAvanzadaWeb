
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;




namespace Abstracciones.Interfaces.API
{
    public interface IRestauranteController
    {

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(RestauranteRequest restaurante);
        Task<IActionResult> Editar(Guid Id, RestauranteRequest restaurante);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
