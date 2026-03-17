using Abstracciones.DA;
using Abstracciones.Modelos;
using Dapper;
using Helpers;
using System.Data;
using System.Data.SqlClient;

namespace DA
{
    public class UsuarioDA : IUsuarioDA
    {
        IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> CrearUsuario(ClienteCompleto clienteCompleto)
        {
            var sql = @"CrearUsuarioCliente";

            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(
                sql,
                new
                {
                    Id = Guid.NewGuid(),
                    Correo = clienteCompleto.Usuario.Correo,
                    Password = clienteCompleto.Usuario.Password,
                    idRol = clienteCompleto.Usuario.idRol,
                    Nombre = clienteCompleto.Cliente.Nombre,
                    Direccion = clienteCompleto.Cliente.Direccion,
                    MetodoPago = clienteCompleto.Cliente.MetodoPago
                });
            return resultado;
        }

        public async Task<IEnumerable<RolResponse>> ObtenerRolxUsuario(Usuario usuario)
        {
            string sql = @"ObtenerRolxUsuario";
            var resultado = await _sqlConnection.QueryAsync<RolResponse>(sql, 
            new { 
                Correo = usuario.Correo,
            });
            return resultado;
        }

        public async Task<Usuario> ObtenerUsuario(LoginBase login)
        {
            string sql = @"ObtenerUsuario";
            var resultado = await _sqlConnection.QueryAsync<Usuario>(sql, 
            new { 
                Nombre = login.NombreUsuario,
                Correo = login.CorreoElectronico
            });
            return resultado.FirstOrDefault();
        }
    }
}
