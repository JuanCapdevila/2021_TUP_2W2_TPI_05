using System;
namespace Resultados
{
    public class ResultadoApi
    {

        public bool OK { get; set; }
        public string Error { get; set; }
        public string InfoAdicional { get; set; }
        public Object Return { get; set; }
        public int CodigoError { get; set; }

        public ResultadoApi(){

         }
    }

}