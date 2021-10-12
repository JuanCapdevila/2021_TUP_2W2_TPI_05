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
using TPI_MSI.Comandos;

namespace TPI_MSI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class LoginController : ControllerBase
    {
        private readonly EASYSTOCKBDContext db = new EASYSTOCKBDContext();


        public LoginController()
        {

        }
        // MOSTRAR TODOS LAS MARCAS 
        [HttpPost]
        [Route("Login/ValidarDatos")]
        public ActionResult<ResultadoApi> Post([FromBody] ComandoUsuario comando)
        {
            ResultadoApi resultado = new ResultadoApi();
            try
            {

                var usu = db.Usuarios.FirstOrDefault(x => x.Usuario1.Equals(comando.usuario) && x.Contrasenia.Equals(comando.Contrasenia) && x.Idrolfk.Equals(comando.Idrol));

                if (usu == null)
                {
                    resultado.OK = false;
                    resultado.Error = "Usuario, contraseña o rol incorrectos";
                }
                else
                {
                    resultado.OK = true;
                    resultado.Return = usu;
                }
            }
            catch
            {
                resultado.OK = false;
                resultado.Error = "No se pudo establecer conexión con la Base de Datos";
            }

            return resultado;
        }
    }
}