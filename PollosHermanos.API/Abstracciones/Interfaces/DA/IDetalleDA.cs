using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IDetalleDA
    {
        Task<IEnumerable<DetalleResponse>> Obtener();
        Task<Guid> Agregar(DetalleRequest detalle);
        Task<Guid> Editar(Guid idPedido, Guid idProducto, DetalleRequest detalle);
        Task<Guid> Eliminar(Guid idPedido, Guid idProducto);
    }
}
