using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IReservaFlujo
    {

        Task<IEnumerable<ReservaResponse>> Obtener();
        Task<ReservaResponse> Obtener(Guid Id);
        Task<Guid> Agregar(ReservaRequest reserva);
        Task<Guid> Editar(Guid Id, ReservaRequest reserva);
        Task<Guid> Eliminar(Guid Id);

    }
}
