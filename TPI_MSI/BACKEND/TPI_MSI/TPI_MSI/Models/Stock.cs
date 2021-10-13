using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Stock
    {
        public Stock()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idstock { get; set; }
        public int? Stockactual { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
