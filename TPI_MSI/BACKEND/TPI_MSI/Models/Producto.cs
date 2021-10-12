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

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Idpaisorigent { get; set; }
        public int? Idrubro { get; set; }
        public int? Idmarca { get; set; }
        public int? Idempaquetado { get; set; }
        public decimal? Peso { get; set; }
        public string Unidadmedicion { get; set; }
        public int? Esfragil { get; set; }
        public int? Idstock { get; set; }

        [ForeignKey("Id")]
        public virtual Empaquetado IdempaquetadoNavigation { get; set; }
        [ForeignKey("Id")]
        public virtual Marca IdmarcaNavigation { get; set; }
        [ForeignKey("Id")]
        public virtual PaisesOrigen IdpaisorigentNavigation { get; set; }
        [ForeignKey("Id")]
        public virtual Rubro IdrubroNavigation { get; set; }
        [ForeignKey("Id")]
        public virtual Stock IdstockNavigation { get; set; }
        public virtual ICollection<DetallesDespacho> DetallesDespachos { get; set; }
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
