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
using Comandos.ComandoAltaProducto;
using TPI_MSI.Comandos;

namespace TPI_MSI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class ActualizarProductoController : ControllerBase
    {
        private readonly EASYSTOCKBDContext  db = new EASYSTOCKBDContext();
    

        public ActualizarProductoController()
        {

        }

// 
        [HttpPost]
        [Route("Productos/ModificarProducto")]
        public ActionResult<ResultadoApi> AltaProdcuto([FromBody]ComandoModificarProducto comando)
        {
            ResultadoApi respuesta = new ResultadoApi();
            var id = comando.Id;
            var nombre = comando.Nombre.Trim();
            var descripcion = comando.Descripcion.Trim();
            var idpaisorigent = comando.Idpaisorigent;
            var idrubro = comando.Idrubro;
            var idmarca = comando.Idmarca;
            var idempaquetado = comando.Idempaquetado;
            var peso = comando.Peso;
            var unidadMedicion = comando.Unidadmedicion;
            var esFragil = comando.Esfragil;
            var idstock = comando.Idstock;

            if(string.IsNullOrEmpty(nombre)){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un nombre";
                return respuesta;
            }
            if(string.IsNullOrEmpty(descripcion)){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar una descripcion";
                return respuesta;
            }
            if(idpaisorigent==0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un id de país de origen";
                return respuesta;
            }
            if(idrubro == 0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un id de rubro";
                return respuesta;
            }
            if(idmarca==0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un id de marca";
                return respuesta;
            }
            if(idempaquetado == 0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un tipo de empaquetado";
                return respuesta;
            }
            if(peso == 0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un id de barrio";
                return respuesta;
            }
            if (peso.Equals(""))
            {
                respuesta.OK = false;
                respuesta.Error = "Ingrese peso, no puede estar vacío";
                return respuesta;
            }
            if(string.IsNullOrEmpty(unidadMedicion)){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar una unidad de medicion";
                return respuesta;
            }
            if(idstock == 0){
                respuesta.OK=false;
                respuesta.Error = "Debe ingresar un id de stock";
                return respuesta;
            }

            var producto = db.Productos.FirstOrDefault(x => x.Idproducto == comando.Id);

            producto.Nombre = comando.Nombre;
            producto.Descripcion = comando.Descripcion;
            producto.Idpaisorigenfk = comando.Idpaisorigent;
            producto.Idrubrofk = comando.Idrubro;
            producto.Idmarcafk = comando.Idmarca;
            producto.Idstockfk = comando.Idstock;
            producto.Idempaquetadofk = comando.Idempaquetado;
            producto.Peso = comando.Peso;
            producto.Unidadmedicion = comando.Unidadmedicion;
            producto.Esfragil = comando.Esfragil;


            db.Productos.Update(producto);
            db.SaveChanges();

            respuesta.OK=true;
            respuesta.Return=db.Productos.FirstOrDefault(x => x.Idproducto == comando.Id);
            return respuesta;

        } // fin  Alta PRODUCTOS

        






    }
}
