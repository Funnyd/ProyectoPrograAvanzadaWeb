using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class RestauranteDA : IRestauranteDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public RestauranteDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(RestauranteRequest restaurante)
        {
            string query = @"CrearRestaurante";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Ubicacion = restaurante.Ubicacion
            }); 
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, RestauranteRequest restaurante)
        {
            await verificarRestaurante(Id);
            string query = @"EditarRestaurante";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Ubicacion = restaurante.Ubicacion
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarRestaurante(Id);
            string query = @"EliminarRestaurante";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<RestauranteResponse>> Obtener()
        {
            string query = @"ObtenerRestaurantes";
            var resultado = await _sqlConnection.QueryAsync<RestauranteResponse>(query);
            return resultado;
        }


        public async Task<RestauranteResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerRestaurantePorId";
            var resultado = await _sqlConnection.QueryAsync<RestauranteResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarRestaurante(Guid Id)
        {
            RestauranteResponse? resultadoRestaurante = await Obtener(Id);
            if (resultadoRestaurante == null)
            { throw new Exception("No se encontró el restaurante"); }
        }

        #endregion

    }
}
