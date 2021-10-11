using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using Microsoft.CSharp.RuntimeBinder;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.CompilerServices;
using System.Security.Cryptography;
using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Resultados;
using TPI_MSI.Models;
using Comandos.ComandoListadoProductos;


namespace TPI_MSI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class ListaDeProductosController : ControllerBase
    {
        private readonly StockBDContext  db = new StockBDContext();
    

        public ListaDeProductosController()
        {

        }
// https://tup-msi-grupo5.atlassian.net/browse/IG2021-55 Crear Api para cargar la lista de productos 
// 
        [HttpPost]
          [Route("Productos/ObtenerListadoDeProductos")]
        public ActionResult<ResultadoApi> Get2([FromBody]ComandoListadoProductos comando)
        {
            var resultado = new ResultadoApi();
            if (comando.IdRubro==0 && comando.IdMarca == 0 && comando.IdEmpaquetado == 0)
            {
                 try
            {

                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       IDRUBRO = p.Idrubro,
                       RUBRO = r.Descripcion                                                                       
                    }).ToList();   
                 resultado.Return= query;
                return resultado;
            }
            catch (System.Exception)
            {
                resultado.OK = false;
                resultado.CodigoError = 1;
                resultado.Error = "Error al intentar mostrar Productos";
                return resultado;
            }

            } else {

                 try
            {

                resultado.OK = true;
         
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id
                    where p.Idrubro == comando.IdRubro  
                    orderby p.Id select new {  
                       
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       IDRUBRO = p.Idrubro,
                      RUBRO = r.Descripcion                       
                                                  
                    }).ToList();   

                 resultado.Return= query;

                return resultado;
            }
            catch (System.Exception)

            {
                resultado.OK = false;
                resultado.CodigoError = 1;
                resultado.Error = "Error al intentar mostrar Productos";

                return resultado;
            }
          }
         
         
        


        } // fin  MOSTRAR TODOS LOS PRODUCTOS

// https://tup-msi-grupo5.atlassian.net/browse/IG2021-45 Crear Api para obtener productos






    }
}
