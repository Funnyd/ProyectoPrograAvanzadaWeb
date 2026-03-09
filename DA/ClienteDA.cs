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
    public class ClienteDA : IClienteDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public ClienteDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(ClienteRequest cliente)
        {
            string query = @"CrearCliente";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idUsuario = cliente.idUsuario,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                MetodoPago = cliente.MetodoPago
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, ClienteRequest cliente)
        {
            await verificarCliente(Id);
            string query = @"EditarCliente";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                idUsuario = Id,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                MetodoPago = cliente.MetodoPago
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarCliente(Id);
            string query = @"EliminarCliente";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<ClienteResponse>> Obtener()
        {
            string query = @"ObtenerClientes";
            var resultado = await _sqlConnection.QueryAsync<ClienteResponse>(query);
            return resultado;
        }


        public async Task<ClienteResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerClientePorId";
            var resultado = await _sqlConnection.QueryAsync<ClienteResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarCliente(Guid Id)
        {
            ClienteResponse? resultadoCliente = await Obtener(Id);
            if (resultadoCliente == null)
            { throw new Exception("No se encontró el cliente"); }
        }

        #endregion

    }
}
