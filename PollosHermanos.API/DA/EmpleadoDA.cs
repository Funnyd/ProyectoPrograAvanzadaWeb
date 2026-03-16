using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;


namespace DA
{
    public class EmpleadoDA : IEmpleadoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public EmpleadoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(EmpleadoRequest empleado)
        {
            string query = @"CrearEmpleado";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                idUsuario = empleado.idUsuario,
                Nombre = empleado.Nombre,
                idRestaurante = empleado.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, EmpleadoRequest empleado)
        {
            string query = @"EditarEmpleado";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                idUsuario = Id,
                Nombre = empleado.Nombre,
                idRestaurante = empleado.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarEmpleado(Id);
            string query = @"EliminarEmpleado";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                idUsuario = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<EmpleadoResponse>> Obtener()
        {
            string query = @"ObtenerEmpleados";
            var resultado = await _sqlConnection.QueryAsync<EmpleadoResponse>(query);
            return resultado;
        }


        public async Task<EmpleadoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerEmpleadoPorId";
            var resultado = await _sqlConnection.QueryAsync<EmpleadoResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarEmpleado(Guid Id)
        {
            EmpleadoResponse? resultadoEmpleado = await Obtener(Id);
            if (resultadoEmpleado == null)
            { throw new Exception("No se encontró el empleado"); }
        }

        #endregion

    }
}
