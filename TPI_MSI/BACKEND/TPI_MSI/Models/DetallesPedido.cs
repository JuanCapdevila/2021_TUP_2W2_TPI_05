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

        public int Id { get; set; }
        public int? Idpedido { get; set; }
        public int? Idproducto { get; set; }
        public int? Cantidadpedida { get; set; }
        public int? Cantidadrecibida { get; set; }

        public virtual Pedido IdpedidoNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
        public virtual ICollection<DetallesPedidoXEstante> DetallesPedidoXEstantes { get; set; }
    }
}
