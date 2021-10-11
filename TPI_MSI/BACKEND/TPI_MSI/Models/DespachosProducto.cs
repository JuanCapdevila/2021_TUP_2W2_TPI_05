using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DespachosProducto
    {
        public DespachosProducto()
        {
            DetallesDespachos = new HashSet<DetallesDespacho>();
        }

        public int Id { get; set; }
        public DateTime? Fechaegreso { get; set; }
        public TimeSpan? Horaegreso { get; set; }
        public int? Iddestinatario { get; set; }

        public virtual Destinatario IddestinatarioNavigation { get; set; }
        public virtual ICollection<DetallesDespacho> DetallesDespachos { get; set; }
    }
}
