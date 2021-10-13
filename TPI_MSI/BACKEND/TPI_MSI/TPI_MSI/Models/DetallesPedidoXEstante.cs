using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesPedidoXEstante
    {
        public int Iddetallepedidoxestante { get; set; }
        public int? IddetallesPedidofk { get; set; }
        public int? Idestantefk { get; set; }
        public int? Cantidad { get; set; }

        public virtual DetallesPedido IddetallesPedidofkNavigation { get; set; }
        public virtual Estante IdestantefkNavigation { get; set; }
    }
}
