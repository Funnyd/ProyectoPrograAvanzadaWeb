using Autorizacion.Abstracciones.Flujo;
using Autorizacion.Abstracciones.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Autorizacion.Flujo
{
    public class AutorizacionFlujo : IAutorizacionFlujo
    {
        private ISeguridadDA _seguridadDA;

        public AutorizacionFlujo(ISeguridadDA seguridadDA)
        {
            _seguridadDA = seguridadDA;
        }

        public async Task<IEnumerable<RolBase>> ObtenerRolxUsuario(Usuario usuario)
        {
            return await _seguridadDA.ObtenerRolxUsuario(usuario);
        }

        public async Task<Usuario> ObtenerUsuario(Cliente cliente)
        {
            return await _seguridadDA.ObtenerUsuario(cliente);
        }
    }
}
