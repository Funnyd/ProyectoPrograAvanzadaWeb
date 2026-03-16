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
    public class DetalleDA : IDetalleDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public DetalleDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(DetalleRequest detalle)
        {
            string query = @"CrearDetalle";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                cantidad = detalle.Cantidad,
                precioUnitario = detalle.PrecioUnitario,
                idPedido = detalle.idPedido,
                idProducto = detalle.idProducto
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid idPedido, Guid idProducto, DetalleRequest detalle)
        {
            string query = @"EditarDetalle";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                cantidad = detalle.Cantidad,
                precioUnitario = detalle.PrecioUnitario,
                idPedido = idPedido,
                idProducto = idProducto,
                idPedidoNuevo = detalle.idPedido,
                idProductoNuevo = detalle.idProducto
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid idPedido, Guid idProducto)
        {
            string query = @"EliminarDetalle";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idPedido = idPedido,
                idProducto = idProducto
            });
            return resultado;
        }

        public async Task<IEnumerable<DetalleResponse>> Obtener()
        {
            string query = @"ObtenerDetalles";
            var resultado = await _sqlConnection.QueryAsync<DetalleResponse>(query);
            return resultado;
        }

        #endregion


    }
}
