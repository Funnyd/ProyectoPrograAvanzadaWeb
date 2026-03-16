using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Reserva
    {
        [Required(ErrorMessage = "El campo Cantidad de Personas es requerido")]
        public int CantidadPersonas { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }


    }

    public class ReservaRequest : Reserva
    {
        public Guid idCliente { get; set; }
        public Guid idRestaurante { get; set; }
    }

    public class ReservaResponse : Reserva
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Restaurante { get; set; } = string.Empty;

    }
}
