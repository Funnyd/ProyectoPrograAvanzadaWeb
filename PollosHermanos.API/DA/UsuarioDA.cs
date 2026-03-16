using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class UsuarioDA : IUsuarioDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(UsuarioRequest usuario)
        {
            string query = @"CrearUsuario";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Correo = usuario.Correo,
                Password = usuario.Password,
                IdRol = usuario.idRol
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, UsuarioRequest usuario)
        {
            await verificarUsuario(Id);
            string query = @"EditarUsuario";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id,
                Correo = usuario.Correo,
                Password = usuario.Password,
                IdRol = usuario.idRol
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarUsuario(Id);
            string query = @"EliminarUsuario";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<UsuarioResponse>> Obtener()
        {
            string query = @"ObtenerUsuarios";
            var resultado = await _sqlConnection.QueryAsync<UsuarioResponse>(query);
            return resultado;
        }


        public async Task<UsuarioResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerUsuarioPorId";
            var resultado = await _sqlConnection.QueryAsync<UsuarioResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarUsuario(Guid Id)
        {
            UsuarioResponse? resultadoUsuario = await Obtener(Id);
            if (resultadoUsuario == null)
            { throw new Exception("No se encontró el usuario"); }
        }

        #endregion

    }
}
