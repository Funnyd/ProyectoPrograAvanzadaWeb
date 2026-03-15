using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPedidoFlujo
    {

        Task<IEnumerable<PedidoResponse>> Obtener();
        Task<PedidoResponse> Obtener(Guid Id);
        Task<Guid> Agregar(PedidoRequest pedido);
        Task<Guid> Editar(Guid Id, PedidoRequest pedido);
        Task<Guid> Eliminar(Guid Id);

    }
}
