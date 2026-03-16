using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Menu
    {

    }

    public class MenuRequest : Menu
    {
        public Guid idRestaurante { get; set; }
        public Guid idProducto { get; set; }

    }

    public class MenuResponse : Menu
    {
        public string Restaurante { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;

    }
}
