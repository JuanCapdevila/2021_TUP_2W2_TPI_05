using System;
using System.Collections.Generic;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idrol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
