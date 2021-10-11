using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public int? Numeroremito { get; set; }
        public string Descripcion { get; set; }
        public int? Idproveedor { get; set; }
        public DateTime? Fechapedido { get; set; }
        public DateTime? Fecharecepcion { get; set; }
        public DateTime? Fecharealingreso { get; set; }
        public int? Idestado { get; set; }

        public virtual Estado IdestadoNavigation { get; set; }
        public virtual Proveedore IdproveedorNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
