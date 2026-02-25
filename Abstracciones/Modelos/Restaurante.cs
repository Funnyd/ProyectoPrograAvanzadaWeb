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
        [Required(ErrorMessage = "El campo ubicación es requerido")]
        public string Ubicación { get; set; }

        public class RestauranteRequest : Restaurante
        {
            public Guid id { get; set; }
        }

        public class RestauranteResponse : Restaurante
        {
            public Guid Id { get; set; }
        }
    }
}
