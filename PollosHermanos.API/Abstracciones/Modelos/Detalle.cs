using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Detalle
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class DetalleRequest : Detalle
    {
        public Guid idPedido { get; set; }
        public Guid idProducto { get; set; }
    }

    public class DetalleResponse : Detalle
    {
        public Guid idPedido { get; set; }
        public string Producto { get; set; } = string.Empty;

    }
}
