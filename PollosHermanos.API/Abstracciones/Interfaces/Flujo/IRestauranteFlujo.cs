using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IRestauranteFlujo
    {

        Task<IEnumerable<RestauranteResponse>> Obtener();
        Task<RestauranteResponse> Obtener(Guid Id);
        Task<Guid> Agregar(RestauranteRequest restaurante);
        Task<Guid> Editar(Guid Id, RestauranteRequest restaurante);
        Task<Guid> Eliminar(Guid Id);
    }
}
