using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class UsuarioBase
    {
        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ingrese un correo valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }

    public class UsuarioRequest : Usuario
    {
        public Guid idRol { get; set; }

    }
    public class Usuario: UsuarioBase
    {
        public Guid Id { get; set; }
        public Guid idRol { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
    }
}
