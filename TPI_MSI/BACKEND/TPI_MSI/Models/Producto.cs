using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesDespachos = new HashSet<DetallesDespacho>();
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Idpaisorigenfk { get; set; }
        public int? Idrubrofk { get; set; }
        public int? Idmarcafk { get; set; }
        public int? Idempaquetadofk { get; set; }
        public decimal? Peso { get; set; }
        public string Unidadmedicion { get; set; }
        public int? Esfragil { get; set; }
        public int? Idstockfk { get; set; }

        public virtual Empaquetado IdempaquetadofkNavigation { get; set; }
        public virtual Marca IdmarcafkNavigation { get; set; }
        public virtual PaisesOrigen IdpaisorigenfkNavigation { get; set; }
        public virtual Rubro IdrubrofkNavigation { get; set; }
        public virtual Stock IdstockfkNavigation { get; set; }
        public virtual ICollection<DetallesDespacho> DetallesDespachos { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
