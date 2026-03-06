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
    public class PedidoFlujo : IPedidoFlujo
    {
        private IPedidoDA _pedidoDA;


        public PedidoFlujo(IPedidoDA pedidoDA)
        {
            _pedidoDA = pedidoDA;

        }

        public async Task<Guid> Agregar(PedidoRequest pedido)
        {
            return await _pedidoDA.Agregar(pedido);
        }

        public async Task<Guid> Editar(Guid Id, PedidoRequest pedido)
        {
            return await _pedidoDA.Editar(Id, pedido);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _pedidoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<PedidoResponse>> Obtener()
        {
            return await _pedidoDA.Obtener();
        }

        public async Task<PedidoResponse> Obtener(Guid Id)
        {
            var pedido = await _pedidoDA.Obtener(Id);
            return pedido;
        }
    }
}
