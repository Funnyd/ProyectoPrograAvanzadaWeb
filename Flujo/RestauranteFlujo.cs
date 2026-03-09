using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using static Abstracciones.Modelos.Restaurante;
=======
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5

namespace Flujo
{
    public class RestauranteFlujo : IRestauranteFlujo
    {
        private IRestauranteDA _restauranteDA;

<<<<<<< HEAD
=======

>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        public RestauranteFlujo(IRestauranteDA restauranteDA)
        {
            _restauranteDA = restauranteDA;

        }

<<<<<<< HEAD
        public Task<Guid> Agregar(RestauranteRequest restaurante)
        {
            return await _restauranteDA.Agregar(restaurante); 
        }

        public Task<Guid> Editar(Guid Id, RestauranteRequest restaurante)
=======
        public async Task<Guid> Agregar(RestauranteRequest restaurante)
        {
            return await _restauranteDA.Agregar(restaurante);
        }

        public async Task<Guid> Editar(Guid Id, RestauranteRequest restaurante)
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        {
            return await _restauranteDA.Editar(Id, restaurante);
        }

<<<<<<< HEAD
        public Task<Guid> Eliminar(Guid Id)
=======
        public async Task<Guid> Eliminar(Guid Id)
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        {
            return await _restauranteDA.Eliminar(Id);
        }

<<<<<<< HEAD
        public Task<IEnumerable<RestauranteResponse>> Obtener()
=======
        public async Task<IEnumerable<RestauranteResponse>> Obtener()
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        {
            return await _restauranteDA.Obtener();
        }

<<<<<<< HEAD
        public Task<RestauranteResponse> Obtener(Guid Id)
=======
        public async Task<RestauranteResponse> Obtener(Guid Id)
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        {
            var restaurante = await _restauranteDA.Obtener(Id);
            return restaurante;
        }
    }
}
