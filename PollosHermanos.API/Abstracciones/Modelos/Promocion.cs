using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Promocion
    {
        

        [Required]
        public decimal PorcentajeDescuento { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public bool PromocionValida { get; set; }
    }

    public class PromocionRequest : Promocion
    {
        public Guid idProducto { get; set; }
    }

    public class PromocionResponse : Promocion
    {
        public Guid Id { get; set; }
        public string Producto { get; set; }
    }
}