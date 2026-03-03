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
    public class ClienteFlujo : IClienteFlujo
    {
        private IClienteDA _clienteDA;


        public ClienteFlujo(IClienteDA clienteDA)
        {
            _clienteDA = clienteDA;

        }

        public async Task<Guid> Agregar(ClienteRequest cliente)
        {
            return await _clienteDA.Agregar(cliente);
        }

        public async Task<Guid> Editar(Guid Id, ClienteRequest cliente)
        {
            return await _clienteDA.Editar(Id, cliente);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _clienteDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ClienteResponse>> Obtener()
        {
            return await _clienteDA.Obtener();
        }

        public async Task<ClienteResponse> Obtener(Guid Id)
        {
            var cliente = await _clienteDA.Obtener(Id);
            return cliente;
        }
    }
}
