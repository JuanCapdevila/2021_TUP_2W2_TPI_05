using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Estante
    {
        public Estante()
        {
            DetallesDespachoXEstantes = new HashSet<DetallesDespachoXEstante>();
            DetallesPedidoXEstantes = new HashSet<DetallesPedidoXEstante>();
        }

        public int Id { get; set; }
        public int? Idrack { get; set; }
        public string Descripcion { get; set; }
        public int? Capacidaddisponible { get; set; }

        public virtual Rack IdrackNavigation { get; set; }
        public virtual ICollection<DetallesDespachoXEstante> DetallesDespachoXEstantes { get; set; }
        public virtual ICollection<DetallesPedidoXEstante> DetallesPedidoXEstantes { get; set; }
    }
}
