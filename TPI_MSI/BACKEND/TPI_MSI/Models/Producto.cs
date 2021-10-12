using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Idempaquetadofk")]
        public virtual Empaquetado IdempaquetadofkNavigation { get; set; }
        [ForeignKey("Idmarcafk")]
        public virtual Marca IdmarcafkNavigation { get; set; }
        [ForeignKey("Idpaisorigenfk")]
        public virtual PaisesOrigen IdpaisorigenfkNavigation { get; set; }
        [ForeignKey("Idrubrofk")]
        public virtual Rubro IdrubrofkNavigation { get; set; }
        [ForeignKey("Idstockfk")]
        public virtual Stock IdstockfkNavigation { get; set; }
        public virtual ICollection<DetallesDespacho> DetallesDespachos { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
