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
    public class AutenticacionFlujo : IAutenticacionFlujo
    {
        private ISeguridadDA _seguridadDA;
        
        public AutenticacionFlujo(ISeguridadDA seguridadDA)
        {
            _seguridadDA = seguridadDA;
        }
        
        public Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
