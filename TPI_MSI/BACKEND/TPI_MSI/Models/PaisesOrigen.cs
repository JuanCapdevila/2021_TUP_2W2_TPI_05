using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class PaisesOrigen
    {
        public PaisesOrigen()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string PaisOrigen { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
