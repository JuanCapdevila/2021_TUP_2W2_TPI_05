using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Ubicacione
    {
        public Ubicacione()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public int? Idestante { get; set; }
        public bool? Disponible { get; set; }

        public virtual Estante IdestanteNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
