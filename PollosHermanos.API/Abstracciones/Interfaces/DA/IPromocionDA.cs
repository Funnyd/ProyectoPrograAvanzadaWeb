using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IPromocionDA
    {
        Task<IEnumerable<PromocionResponse>> Obtener();
        Task<PromocionResponse> Obtener(Guid Id);
        Task<Guid> Agregar(PromocionRequest promocion);
        Task<Guid> Editar(Guid Id, PromocionRequest promocion);
        Task<Guid> Eliminar(Guid Id);
    }
}
