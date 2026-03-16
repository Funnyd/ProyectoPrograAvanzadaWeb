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
    public class PromocionFlujo : IPromocionFlujo
    {
        private IPromocionDA _promocionDA;

        public PromocionFlujo(IPromocionDA promocionDA)
        {
            _promocionDA = promocionDA;
        }

        public async Task<Guid> Agregar(PromocionRequest promocion)
        {
            return await _promocionDA.Agregar(promocion);
        }

        public async Task<Guid> Editar(Guid Id, PromocionRequest promocion)
        {
            return await _promocionDA.Editar(Id, promocion);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _promocionDA.Eliminar(Id);
        }

        public async Task<IEnumerable<PromocionResponse>> Obtener()
        {
            return await _promocionDA.Obtener();
        }

        public async Task<PromocionResponse> Obtener(Guid Id)
        {
            return await _promocionDA.Obtener(Id);
        }
    }
}