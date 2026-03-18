using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizacion.Abstracciones.DA
{
    public interface ISeguridadDA
    {
        Task<IEnumerable<RolBase>> ObtenerRolxUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuario(Cliente cliente);
    }
}
