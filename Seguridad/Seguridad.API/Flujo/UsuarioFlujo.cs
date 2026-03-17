using Abstracciones.Flujo;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class UsuarioFlujo : IUsuarioFlujo
    {
        private IUsuarioDA _usuarioDA;

        public UsuarioFlujo(IUsuarioDA usuarioDA)
        {
            _usuarioDA = usuarioDA;
        }

        public async Task<Guid> CrearUsuario(ClienteCompleto clienteCompleto)
        {
            return await _usuarioDA.CrearUsuario(clienteCompleto);
        }

        public async Task<Usuario> ObtenerUsuario(LoginBase login)
        {
            return await _usuarioDA.ObtenerUsuario(login);
        }
    }
}
