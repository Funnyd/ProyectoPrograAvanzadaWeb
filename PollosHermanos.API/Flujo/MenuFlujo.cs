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
    public class MenuFlujo : IMenuFlujo
    {
        private IMenuDA _menuDA;



        public MenuFlujo(IMenuDA menuDA)
        {
            _menuDA = menuDA;

        }

        public async Task<Guid> Agregar(MenuRequest menu)
        {
            return await _menuDA.Agregar(menu);
        }

        public async Task<Guid> Editar(Guid idRestaurante, Guid idProducto, MenuRequest menu)
        {
            return await _menuDA.Editar(idRestaurante, idProducto, menu);
        }

        public async Task<Guid> Eliminar(Guid idRestaurante, Guid idProducto)
        {
            return await _menuDA.Eliminar(idRestaurante, idProducto);
        }

        public async Task<IEnumerable<MenuResponse>> Obtener()
        {
            return await _menuDA.Obtener();
        }

    }
}
