using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Razonsocial { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
