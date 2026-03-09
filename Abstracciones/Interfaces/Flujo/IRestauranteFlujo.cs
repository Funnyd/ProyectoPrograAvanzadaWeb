<<<<<<< HEAD
﻿using System;
=======
﻿using Abstracciones.Modelos;
using System;
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using static Abstracciones.Modelos.Restaurante;
=======
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5

namespace Abstracciones.Interfaces.Flujo
{
    public interface IRestauranteFlujo
    {
<<<<<<< HEAD
=======

>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        Task<IEnumerable<RestauranteResponse>> Obtener();
        Task<RestauranteResponse> Obtener(Guid Id);
        Task<Guid> Agregar(RestauranteRequest restaurante);
        Task<Guid> Editar(Guid Id, RestauranteRequest restaurante);
        Task<Guid> Eliminar(Guid Id);
    }
}
