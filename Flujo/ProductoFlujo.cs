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
    public class ProductoFlujo : IProductoFlujo
    {
        private IProductoDA _productoDA;


        public ProductoFlujo(IProductoDA productoDA)
        {
            _productoDA = productoDA;

        }

        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            return await _productoDA.Agregar(producto);
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return await _productoDA.Editar(Id, producto);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _productoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return await _productoDA.Obtener();
        }

        public async Task<ProductoResponse> Obtener(Guid Id)
        {
            var producto = await _productoDA.Obtener(Id);
            return producto;
        }
    }
}
