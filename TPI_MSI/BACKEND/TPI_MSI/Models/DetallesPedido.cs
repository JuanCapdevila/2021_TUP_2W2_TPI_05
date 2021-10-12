using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesPedido
    {
        public DetallesPedido()
        {
            DetallesPedidoXEstantes = new HashSet<DetallesPedidoXEstante>();
        }

        public int Iddetallepedido { get; set; }
        public int? Idpedidofk { get; set; }
        public int? Idproductofk { get; set; }
        public int? Cantidadpedida { get; set; }
        public int? Cantidadrecibida { get; set; }

        public virtual Pedido IdpedidofkNavigation { get; set; }
        public virtual Producto IdproductofkNavigation { get; set; }
        public virtual ICollection<DetallesPedidoXEstante> DetallesPedidoXEstantes { get; set; }
    }
}
