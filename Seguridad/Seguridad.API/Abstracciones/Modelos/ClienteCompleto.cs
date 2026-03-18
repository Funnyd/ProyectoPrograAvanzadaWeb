using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ClienteCompleto
    {
        public UsuarioRequest Usuario { get; set; }
        public ClienteBase Cliente { get; set; }
    }
}
