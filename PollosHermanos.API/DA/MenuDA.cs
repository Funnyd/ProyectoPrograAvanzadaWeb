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
    public class MenuDA : IMenuDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public MenuDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(MenuRequest menu)
        {
            string query = @"CrearMenu";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idRestaurante = menu.idRestaurante,
                idProducto = menu.idProducto
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid idRestaurante, Guid idProducto, MenuRequest menu)
        {
            string query = @"EditarMenu";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idRestaurante = idRestaurante,
                idProducto = idProducto,
                idRestauranteNuevo = menu.idRestaurante,
                idProductoNuevo = menu.idProducto
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid idRestaurante, Guid idProducto)
        {
            string query = @"EliminarMenu";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idRestaurante = idRestaurante,
                idProducto = idProducto
            });
            return resultado;
        }

        public async Task<IEnumerable<MenuResponse>> Obtener()
        {
            string query = @"ObtenerMenus";
            var resultado = await _sqlConnection.QueryAsync<MenuResponse>(query);
            return resultado;
        }

        #endregion


    }
}
