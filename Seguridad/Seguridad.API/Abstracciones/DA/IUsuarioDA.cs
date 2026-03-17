using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IUsuarioDA
    {
        Task<Guid> CrearUsuario(ClienteCompleto clienteCompleto);

        Task<IEnumerable<RolResponse>> ObtenerRolxUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuario(LoginBase login);

    }
}
