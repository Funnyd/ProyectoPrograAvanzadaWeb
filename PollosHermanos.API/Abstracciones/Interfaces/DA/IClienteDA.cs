using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IClienteDA
    {
        Task<IEnumerable<ClienteResponse>> Obtener();
        Task<ClienteResponse> Obtener(Guid Id);
        Task<Guid> Agregar(ClienteRequest cliente);
        Task<Guid> Editar(Guid Id, ClienteRequest cliente);
        Task<Guid> Eliminar(Guid Id);
    }
}
