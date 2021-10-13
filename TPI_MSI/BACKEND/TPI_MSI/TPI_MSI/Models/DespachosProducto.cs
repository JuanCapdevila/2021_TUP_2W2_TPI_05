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

        public int Iddespachoproducto { get; set; }
        public DateTime? Fechaegreso { get; set; }
        public TimeSpan? Horaegreso { get; set; }
        public int? Iddestinatariofk { get; set; }

        public virtual Destinatario IddestinatariofkNavigation { get; set; }
        public virtual ICollection<DetallesDespacho> DetallesDespachos { get; set; }
    }
}
