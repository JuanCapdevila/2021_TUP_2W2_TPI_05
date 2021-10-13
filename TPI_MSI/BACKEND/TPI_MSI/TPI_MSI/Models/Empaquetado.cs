using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Empaquetado
    {
        public Empaquetado()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idempaquetado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
