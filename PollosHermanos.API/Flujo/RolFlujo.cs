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
    public class RolFlujo : IRolFlujo
    {
        private IRolDA _rolDA;

        public RolFlujo(IRolDA rolDA)
        {
            _rolDA = rolDA;
        }

        public async Task<IEnumerable<RolResponse>> Obtener()
        {
            return await _rolDA.Obtener();
        }

        public async Task<RolResponse> ObtenerRol(string Rol)
        { 
            return await _rolDA.ObtenerRol(Rol);
        }
    }
}
