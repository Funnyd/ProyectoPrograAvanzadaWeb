using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ingrese un correo valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [PasswordPropertyText]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "La contraseña debe tener al menos 8 caracteres, una mayuscula y un numero")]
        public string Password { get; set; }
    }

    public class UsuarioRequest : Usuario
    {
        public Guid idRol { get; set; }

    }

    public class UsuarioResponse : Usuario
    {
        public Guid Id { get; set; }
        public Guid idRol { get; set; }
        public string Rol { get; set; }
    }
}

