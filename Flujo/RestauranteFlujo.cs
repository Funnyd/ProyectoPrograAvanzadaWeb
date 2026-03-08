using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Abstracciones.Modelos.Restaurante;

namespace Flujo
{
    public class RestauranteFlujo : IRestauranteFlujo
    {
        private IRestauranteDA _restauranteDA;

        public RestauranteFlujo(IRestauranteDA restauranteDA)
        {
            _restauranteDA = restauranteDA;

        }

        public Task<Guid> Agregar(RestauranteRequest restaurante)
        {
            return await _restauranteDA.Agregar(restaurante); 
        }

        public Task<Guid> Editar(Guid Id, RestauranteRequest restaurante)
        {
            return await _restauranteDA.Editar(Id, restaurante);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return await _restauranteDA.Eliminar(Id);
        }

        public Task<IEnumerable<RestauranteResponse>> Obtener()
        {
            return await _restauranteDA.Obtener();
        }

        public Task<RestauranteResponse> Obtener(Guid Id)
        {
            var restaurante = await _restauranteDA.Obtener(Id);
            return restaurante;
        }
    }
}
