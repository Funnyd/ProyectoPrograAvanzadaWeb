using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class DetalleFlujo : IDetalleFlujo
    {
        private IDetalleDA _detalleDA;



        public DetalleFlujo(IDetalleDA detalleDA)
        {
            _detalleDA = detalleDA;

        }

        public async Task<Guid> Agregar(DetalleRequest detalle)
        {
            return await _detalleDA.Agregar(detalle);
        }

        public async Task<Guid> Editar(Guid idPedido, Guid idProducto, DetalleRequest detalle)
        {
            return await _detalleDA.Editar(idPedido, idProducto, detalle);
        }

        public async Task<Guid> Eliminar(Guid idPedido, Guid idProducto)
        {
            return await _detalleDA.Eliminar(idPedido, idProducto);
        }

        public async Task<IEnumerable<DetalleResponse>> Obtener()
        {
            return await _detalleDA.Obtener();
        }

    }
}
