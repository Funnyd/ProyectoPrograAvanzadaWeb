using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Producto
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Precio es requerido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public string Descripcion { get; set; }

    }

    public class ProductoRequest : Producto
    {

    }

    public class ProductoResponse : Producto
    {
        public Guid Id { get; set; }
    }
}
