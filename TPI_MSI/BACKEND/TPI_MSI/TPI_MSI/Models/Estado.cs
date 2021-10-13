using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Idestado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
