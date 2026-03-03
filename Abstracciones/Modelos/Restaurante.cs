using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Restaurante
    {

        [Required(ErrorMessage = "El campo Ubicacion es requerido")]
        public string Ubicacion { get; set; }


    }

    public class RestauranteRequest : Restaurante
    {

    }

    public class RestauranteResponse : Restaurante
    {
        public Guid Id { get; set; }
    }
}
