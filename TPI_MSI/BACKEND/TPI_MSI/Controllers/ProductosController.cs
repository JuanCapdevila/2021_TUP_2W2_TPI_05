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


namespace TPI_MSI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class ProductosController : ControllerBase
    {
        private readonly EASYSTOCKBDContext  db = new EASYSTOCKBDContext();
    

        public ProductosController()
        {

        }

// 
        [HttpPost]
        [Route("Productos/AltaProductos")]
        public ActionResult<ResultadoApi> AltaProdcuto([FromBody]ComandoAltaProducto comando)
        {
            ResultadoApi respuesta = new ResultadoApi();
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


            Producto c = new Producto();
            //c.Id=0;
            c.Nombre = nombre;
            c.Descripcion = descripcion;
            c.Idpaisorigenfk = idpaisorigent;
            c.Idrubrofk = idrubro;
            c.Idmarcafk = idmarca;
            c.Idempaquetadofk = idempaquetado;
            c.Peso = peso;
            c.Unidadmedicion=unidadMedicion;
            c.Esfragil = esFragil;
            c.Idstockfk=idstock;

            db.Productos.Add(c);
            db.SaveChanges();

            respuesta.OK=true;
            respuesta.Return=db.Productos.ToList();
            return respuesta;

        } // fin  Alta PRODUCTOS








    }
}
