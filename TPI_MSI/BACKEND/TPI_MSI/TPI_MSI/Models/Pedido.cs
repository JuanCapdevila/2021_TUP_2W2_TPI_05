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

        public int Idpedido { get; set; }
        public int? Numeroremito { get; set; }
        public string Descripcion { get; set; }
        public int? Idproveedorfk { get; set; }
        public DateTime? Fechapedido { get; set; }
        public DateTime? Fecharecepcion { get; set; }
        public DateTime? Fecharealingreso { get; set; }
        public int? Idestadofk { get; set; }

        public virtual Estado IdestadofkNavigation { get; set; }
        public virtual Proveedore IdproveedorfkNavigation { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
