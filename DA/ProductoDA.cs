using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ProductoDA : IProductoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public ProductoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            string query = @"CrearProducto";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion
            }); 
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            await verificarProducto(Id);
            string query = @"EditarProducto";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarProducto(Id);
            string query = @"EliminarProducto";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            string query = @"ObtenerProductos";
            var resultado = await _sqlConnection.QueryAsync<ProductoResponse>(query);
            return resultado;
        }


        public async Task<ProductoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerProductoPorId";
            var resultado = await _sqlConnection.QueryAsync<ProductoResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarProducto(Guid Id)
        {
            ProductoResponse? resultadoProducto = await Obtener(Id);
            if (resultadoProducto == null)
            { throw new Exception("No se encontró el producto"); }
        }

        #endregion

    }
}
