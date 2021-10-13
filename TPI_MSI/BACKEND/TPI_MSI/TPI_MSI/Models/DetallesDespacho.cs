using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesDespacho
    {
        public DetallesDespacho()
        {
            DetallesDespachoXEstantes = new HashSet<DetallesDespachoXEstante>();
        }

        public int Iddetalledespacho { get; set; }
        public int? Iddespachofk { get; set; }
        public int? Idproductofk { get; set; }

        public virtual DespachosProducto IddespachofkNavigation { get; set; }
        public virtual Producto IdproductofkNavigation { get; set; }
        public virtual ICollection<DetallesDespachoXEstante> DetallesDespachoXEstantes { get; set; }
    }
}
