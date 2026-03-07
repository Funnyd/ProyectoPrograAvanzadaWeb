using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
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

        public async Task<Guid> Agregar(UsuarioRequest usuario)
        {
            return await _usuarioDA.Agregar(usuario);
        }

        public async Task<Guid> Editar(Guid Id, UsuarioRequest usuario)
        {
            return await _usuarioDA.Editar(Id, usuario);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _usuarioDA.Eliminar(Id);
        }

        public async Task<IEnumerable<UsuarioResponse>> Obtener()
        {
            return await _usuarioDA.Obtener();
        }

        public async Task<UsuarioResponse> Obtener(Guid Id)
        {
            var usuario = await _usuarioDA.Obtener(Id);
            return usuario;
        }
    }
}
