using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizacion.Abstracciones.Flujo
{
    public interface IAutorizacionFlujo
    {
        Task<IEnumerable<RolBase>> ObtenerRolxUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuario(Cliente cliente);
    }
}
