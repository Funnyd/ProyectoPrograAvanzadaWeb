using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IMenuDA
    {
        Task<IEnumerable<MenuResponse>> Obtener();
        Task<Guid> Agregar(MenuRequest menu);
        Task<Guid> Editar(Guid idRestaurante, Guid idProducto, MenuRequest menu);
        Task<Guid> Eliminar(Guid idRestaurante, Guid idProducto);
    }
}
