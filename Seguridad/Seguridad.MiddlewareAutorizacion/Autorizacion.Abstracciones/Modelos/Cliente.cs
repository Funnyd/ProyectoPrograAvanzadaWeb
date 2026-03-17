using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ClienteBase
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo de Pago es requerido")]
        public string? MetodoPago { get; set; }


    }

    public class ClienteRequest : ClienteBase
    {
        public Guid idUsuario { get; set; }
    }

    public class Cliente : ClienteBase
    {
        public Guid idUsuario { get; set; }
        public string Correo { get; set; } = string.Empty;

    }
}
