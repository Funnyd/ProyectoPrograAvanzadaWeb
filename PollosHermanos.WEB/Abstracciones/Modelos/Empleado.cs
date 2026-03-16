using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Empleado
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Nombre solo puede tener letras y espacios ")]
        public string Nombre { get; set; }

    }

    public class EmpleadoRequest : Empleado
    {
        public Guid idUsuario { get; set; }
        public Guid idRestaurante { get; set; }
    }

    public class EmpleadoResponse : Empleado
    {
        public Guid idUsuario { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

    }
}
