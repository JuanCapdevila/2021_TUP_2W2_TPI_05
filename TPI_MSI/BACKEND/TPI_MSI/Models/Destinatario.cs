using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Destinatario
    {
        public Destinatario()
        {
            DespachosProductos = new HashSet<DespachosProducto>();
        }

        public int Iddestinatario { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<DespachosProducto> DespachosProductos { get; set; }
    }
}
