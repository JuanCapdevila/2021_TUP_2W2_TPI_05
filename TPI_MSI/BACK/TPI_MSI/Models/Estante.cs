using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Estante
    {
        public Estante()
        {
            Ubicaciones = new HashSet<Ubicacione>();
        }

        public int Id { get; set; }
        public int? Idrack { get; set; }
        public int? Cantidadubicaciones { get; set; }
        public int? Capacidaddisponible { get; set; }

        public virtual Rack IdrackNavigation { get; set; }
        public virtual ICollection<Ubicacione> Ubicaciones { get; set; }
    }
}
