using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesPedidoXEstante
    {
        public int Id { get; set; }
        public int? IddetallesPedido { get; set; }
        public int? Idestante { get; set; }
        public int? Cantidad { get; set; }

        public virtual DetallesPedido IddetallesPedidoNavigation { get; set; }
        public virtual Estante IdestanteNavigation { get; set; }
    }
}
