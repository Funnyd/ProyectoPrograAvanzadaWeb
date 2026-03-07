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
    public class PedidoDA : IPedidoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public PedidoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(PedidoRequest pedido)
        {
            string query = @"CrearPedido";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                total = pedido.Total,
                estado = pedido.Estado,
                fecha = pedido.Fecha,
                idCliente = pedido.idCliente,
                idRestaurante = pedido.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, PedidoRequest pedido)
        {
            await verificarPedido(Id);
            string query = @"EditarPedido";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id,
                total = pedido.Total,
                estado = pedido.Estado,
                fecha = pedido.Fecha,
                idCliente = pedido.idCliente,
                idRestaurante = pedido.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarPedido(Id);
            string query = @"EliminarPedido";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<PedidoResponse>> Obtener()
        {
            string query = @"ObtenerPedidos";
            var resultado = await _sqlConnection.QueryAsync<PedidoResponse>(query);
            return resultado;
        }


        public async Task<PedidoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerPedidoPorId";
            var resultado = await _sqlConnection.QueryAsync<PedidoResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarPedido(Guid Id)
        {
            PedidoResponse? resultadoPedido = await Obtener(Id);
            if (resultadoPedido == null)
            { throw new Exception("No se encontró el pedido"); }
        }

        #endregion

    }
}
