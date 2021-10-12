using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesDespachoXEstante
    {
        public int Iddetalledespachoxestante { get; set; }
        public int? IddetallesDespachosfk { get; set; }
        public int? Idestantefk { get; set; }
        public int? Cantidad { get; set; }

        public virtual DetallesDespacho IddetallesDespachosfkNavigation { get; set; }
        public virtual Estante IdestantefkNavigation { get; set; }
    }
}
