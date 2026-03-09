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
    public class EmpleadoFlujo : IEmpleadoFlujo
    {
        private IEmpleadoDA _empleadoDA;


        public EmpleadoFlujo(IEmpleadoDA empleadoDA)
        {
            _empleadoDA = empleadoDA;

        }

        public async Task<Guid> Agregar(EmpleadoRequest empleado)
        {
            return await _empleadoDA.Agregar(empleado);
        }

        public async Task<Guid> Editar(Guid Id, EmpleadoRequest empleado)
        {
            return await _empleadoDA.Editar(Id, empleado);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _empleadoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<EmpleadoResponse>> Obtener()
        {
            return await _empleadoDA.Obtener();
        }

        public async Task<EmpleadoResponse> Obtener(Guid Id)
        {
            var empleado = await _empleadoDA.Obtener(Id);
            return empleado;
        }
    }
}
