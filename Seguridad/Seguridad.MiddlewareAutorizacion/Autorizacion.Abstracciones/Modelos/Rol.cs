using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Rol
    {
        public Guid Id { get; set; }
    }

    

    public class RolResponse : Rol
    {
        public Guid Id { get; set; }
        public string Rol {  get; set; }
    }

}