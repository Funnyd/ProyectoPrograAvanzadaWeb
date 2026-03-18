using Autorizacion.Abstracciones.DA;
using System.Data.SqlClient;
using Dapper;
using Abstracciones.Modelos;


namespace Autorizacion.DA
{
    public class SeguridadDA : ISeguridadDA
    {
        IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;
          
        public SeguridadDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<RolBase>> ObtenerRolxUsuario(Usuario usuario)
        {
            string sql = @"ObtenerRolxUsuario";
            var resultado = await _sqlConnection.QueryAsync<RolBase>(sql,
            new
            {
                Correo = usuario.Correo,
            });
            return resultado;
        }

        public async Task<Usuario> ObtenerUsuario(Cliente cliente)
        {
            string sql = @"ObtenerUsuario";
            var resultado = await _sqlConnection.QueryAsync<Usuario>(sql,
            new
            {
                Nombre = cliente.Nombre,
                Correo = cliente.Correo
            });
            return resultado.FirstOrDefault();
        }
    }
}
