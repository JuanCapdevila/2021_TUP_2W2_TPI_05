using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Rack
    {
        public Rack()
        {
            Estantes = new HashSet<Estante>();
        }

        public int Idrack { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidadestantes { get; set; }

        public virtual ICollection<Estante> Estantes { get; set; }
    }
}
