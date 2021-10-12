using System;
using System.Collections;

namespace Comandos.ComandoAltaProducto {

    public class ComandoAltaProducto {
        //public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Idpaisorigent { get; set; }
        public int? Idrubro { get; set; }
        public int? Idmarca { get; set; }
        public int? Idempaquetado { get; set; }
        public decimal? Peso { get; set; }
        public string Unidadmedicion { get; set; }
        public Boolean Esfragil { get; set; }
        public int? Idstock { get; set; }

        
    }

}