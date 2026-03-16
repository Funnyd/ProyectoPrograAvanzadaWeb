using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Pedido
    {
        [Required(ErrorMessage = "El campo Total es requerido")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }


    }

    public class PedidoRequest : Pedido
    {
        public Guid idCliente { get; set; }
        public Guid idRestaurante { get; set; }
    }

    public class PedidoResponse : Pedido
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Restaurante { get; set; } = string.Empty;

    }
}
