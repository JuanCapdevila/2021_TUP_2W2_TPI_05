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

        public int Id { get; set; }
        public int? Iddespacho { get; set; }
        public int? Idproducto { get; set; }

        public virtual DespachosProducto IddespachoNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
        public virtual ICollection<DetallesDespachoXEstante> DetallesDespachoXEstantes { get; set; }
    }
}
