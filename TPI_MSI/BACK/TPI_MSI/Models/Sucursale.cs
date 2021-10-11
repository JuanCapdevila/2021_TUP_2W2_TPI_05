using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
