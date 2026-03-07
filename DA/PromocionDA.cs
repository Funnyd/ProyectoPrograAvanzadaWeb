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
    public class PromocionDA : IPromocionDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public PromocionDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(PromocionRequest promocion)
        {
            string query = @"CrearPromocion";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                idProducto = promocion.idProducto,
                PorcentajeDescuento = promocion.PorcentajeDescuento,
                FechaVencimiento = promocion.FechaVencimiento,
                PromocionValida = promocion.PromocionValida
            });

            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, PromocionRequest promocion)
        {
            await verificarPromocion(Id);

            string query = @"EditarPromocion";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                idProducto = promocion.idProducto,
                PorcentajeDescuento = promocion.PorcentajeDescuento,
                FechaVencimiento = promocion.FechaVencimiento,
                PromocionValida = promocion.PromocionValida
            });

            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarPromocion(Id);

            string query = @"EliminarPromocion";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });

            return resultado;
        }

        public async Task<IEnumerable<PromocionResponse>> Obtener()
        {
            string query = @"ObtenerPromociones";
            var resultado = await _sqlConnection.QueryAsync<PromocionResponse>(query);
            return resultado;
        }

        public async Task<PromocionResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerPromocionPorId";
            var resultado = await _sqlConnection.QueryAsync<PromocionResponse>(query,
                new { Id = Id });

            return resultado.FirstOrDefault();
        }

        private async Task verificarPromocion(Guid Id)
        {
            PromocionResponse? resultadoPromocion = await Obtener(Id);
            if (resultadoPromocion == null)
                throw new Exception("No se encontró la promoción");
        }
    }
}