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
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [PasswordPropertyText]
        public string Password { get; set; }



    }

    public class UsuarioRequest : Usuario
    {
        public Guid idRol { get; set; }

    }

    public class UsuarioResponse : Usuario
    {
        public Guid Id { get; set; }

        public string Rol {  get; set; }
    }
}
