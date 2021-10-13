using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using System.ComponentModel;
using System.Runtime;
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
        private readonly EASYSTOCKBDContext  db = new EASYSTOCKBDContext();
    

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
            // INI ninguna opción seleccionada
            if (comando.IdRubro==0 && comando.IdMarca == 0 && comando.IdEmpaquetado == 0)
            {
                 try
            {
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubrofk equals r.Idrubro
                                                     join s in db.Stocks on p.Idstockfk equals s.Idstock 
                                                     join m in db.Marcas on p.Idmarcafk equals m.Idmarca                     
                    orderby p.Idproducto select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
         
          } // FIN ninguna opción seleccionada




         /// INI - rubro y marca seleccionada
           if (comando.IdRubro != 0  && comando.IdMarca != 0)
            {
                 try
            {
                
                resultado.OK = true;        
               var query = (from p in db.Productos  join r in db.Rubros on p.Idrubrofk equals r.Idrubro
                                                     join s in db.Stocks on p.Idstockfk equals s.Idstock 
                                                     join m in db.Marcas on p.Idmarcafk equals m.Idmarca    
                    where p.Idrubrofk== comando.IdRubro && p.Idmarcafk== comando.IdMarca                                              
                       orderby p.Idproducto select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - rubro y marca seleccionada
/*
             /// INI - rubro y empaquetado seleccionada
           if (comando.IdRubro != 0  && comando.IdEmpaquetado !=0 )
            {
                 try
            {
                
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                                                     join s in db.Stocks on p.Idstock equals s.Id 
                                                     join m in db.Marcas on p.Idmarca equals m.Id 
                    where  p.Idrubro == comando.IdRubro &&  p.Idempaquetado == comando.IdEmpaquetado                                              
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - rubro y marca seleccionada

            
             /// INI - marca y empaquetado seleccionada
           if (comando.IdMarca != 0  && comando.IdEmpaquetado !=0 )
            {
                 try
            {
                
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                                                     join s in db.Stocks on p.Idstock equals s.Id 
                                                     join m in db.Marcas on p.Idmarca equals m.Id 
                    where ( p.Idmarca == comando.IdMarca &&  p.Idempaquetado == comando.IdEmpaquetado )                                             
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - marca y empaquetado seleccionada

          /// INI - rubro seleccionado
           if (comando.IdRubro != 0 )
            {
                 try
            {
                var rubro = comando.IdRubro;
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                                                     join s in db.Stocks on p.Idstock equals s.Id 
                                                     join m in db.Marcas on p.Idmarca equals m.Id 
                    where p.Idrubro == comando.IdRubro                                                 
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - rubro seleccionado

         /// INI - marca seleccionada
           if (comando.IdMarca != 0 )
            {
                 try
            {
                var rubro = comando.IdRubro;
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                                                     join s in db.Stocks on p.Idstock equals s.Id 
                                                     join m in db.Marcas on p.Idmarca equals m.Id 
                    where p.Idmarca == comando.IdMarca                                                 
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - marca seleccionada

            /// INI - empaquetado seleccionada
           if (comando.IdEmpaquetado != 0 )
            {
                 try
            {
                
                resultado.OK = true;        
                 var query = (from p in db.Productos join r in db.Rubros on p.Idrubro equals r.Id 
                                                     join s in db.Stocks on p.Idstock equals s.Id 
                                                     join m in db.Marcas on p.Idmarca equals m.Id 
                    where p.Idempaquetado == comando.IdEmpaquetado                                                 
                    orderby p.Id select new {                        
                       NOMBRE = p.Nombre,
                       DESCRIPCION = p.Descripcion,
                       STOCK = s.Stockactual,       
                       RUBRO = r.Descripcion,
                       MARCA = m.Descripcion,                                                                      
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
          /// FIN - empaquetado seleccionado

            */

          return resultado;

        } // fin  MOSTRAR TODOS LOS PRODUCTOS

// https://tup-msi-grupo5.atlassian.net/browse/IG2021-45 Crear Api para obtener productos
      /*
        [HttpGet]
        [Route("Producto/ObtenerProducto/{idProducto}")]
           public ActionResult<ResultadoApi> Get456452(int idProducto)
        {
            
            
            
              var resultado = new ResultadoApi();
            try
            {
             
              var producto =  db.Productos.Where(c => c.Id == idProducto).FirstOrDefault();
              resultado.OK = true;
              resultado.Return = producto;
              
              return resultado;
              
            }
            catch(Exception ex)
            {
                resultado.OK = false;
                resultado.CodigoError = 1;
                resultado.Error = "Producto no encontrado - " + ex.Message;

                return resultado;
            }
        }    */




    }
}
