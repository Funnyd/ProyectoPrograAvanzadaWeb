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
    public class ReservaDA : IReservaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public ReservaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(ReservaRequest reserva)
        {
            string query = @"CrearReserva";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                cantidad = reserva.CantidadPersonas,
                estado = reserva.Estado,
                fecha = reserva.Fecha,
                idCliente = reserva.idCliente,
                idRestaurante = reserva.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, ReservaRequest reserva)
        {
            await verificarReserva(Id);
            string query = @"EditarReserva";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id,
                cantidad = reserva.CantidadPersonas,
                estado = reserva.Estado,
                fecha = reserva.Fecha,
                idCliente = reserva.idCliente,
                idRestaurante = reserva.idRestaurante
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarReserva(Id);
            string query = @"EliminarReserva";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<ReservaResponse>> Obtener()
        {
            string query = @"ObtenerReservas";
            var resultado = await _sqlConnection.QueryAsync<ReservaResponse>(query);
            return resultado;
        }


        public async Task<ReservaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerReservaPorId";
            var resultado = await _sqlConnection.QueryAsync<ReservaResponse>(query,
                new { Id = Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarReserva(Guid Id)
        {
            ReservaResponse? resultadoReserva = await Obtener(Id);
            if (resultadoReserva == null)
            { throw new Exception("No se encontró el reserva"); }
        }

        #endregion

    }
}
