using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public int? Idrol { get; set; }
        
        
        [ForeignKey("Id")]
        public virtual Role IdrolNavigation { get; set; }
    }
}
