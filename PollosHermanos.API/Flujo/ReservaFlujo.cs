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
    public class ReservaFlujo : IReservaFlujo
    {
        private IReservaDA _reservaDA;


        public ReservaFlujo(IReservaDA reservaDA)
        {
            _reservaDA = reservaDA;

        }

        public async Task<Guid> Agregar(ReservaRequest reserva)
        {
            return await _reservaDA.Agregar(reserva);
        }

        public async Task<Guid> Editar(Guid Id, ReservaRequest reserva)
        {
            return await _reservaDA.Editar(Id, reserva);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _reservaDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ReservaResponse>> Obtener()
        {
            return await _reservaDA.Obtener();
        }

        public async Task<ReservaResponse> Obtener(Guid Id)
        {
            var reserva = await _reservaDA.Obtener(Id);
            return reserva;
        }
    }
}
