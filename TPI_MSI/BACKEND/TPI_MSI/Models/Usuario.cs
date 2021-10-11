using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasenia { get; set; }
        public int? Idrol { get; set; }

        public virtual Role IdrolNavigation { get; set; }
    }
}
