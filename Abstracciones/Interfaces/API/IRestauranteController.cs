using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using static Abstracciones.Modelos.Restaurante;
=======
>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5

namespace Abstracciones.Interfaces.API
{
    public interface IRestauranteController
    {
<<<<<<< HEAD
=======

>>>>>>> f8cbbdbb13ff4a73c9634710d1ffcd5a1bf2fed5
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(RestauranteRequest restaurante);
        Task<IActionResult> Editar(Guid Id, RestauranteRequest restaurante);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
