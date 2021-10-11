using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? Stockactual { get; set; }
        public int? Idproducto { get; set; }
        public int? Idsucursal { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual Sucursale IdsucursalNavigation { get; set; }
    }
}
