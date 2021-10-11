using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class DetallesDespachoXEstante
    {
        public int Id { get; set; }
        public int? IddetallesDespachos { get; set; }
        public int? Idestante { get; set; }
        public int? Cantidad { get; set; }

        public virtual DetallesDespacho IddetallesDespachosNavigation { get; set; }
        public virtual Estante IdestanteNavigation { get; set; }
    }
}
