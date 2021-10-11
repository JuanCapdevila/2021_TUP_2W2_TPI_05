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

namespace TPI_MSI.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class EmpaquetadoController : ControllerBase
    {
        private readonly EASYSTOCKBDContext  db = new EASYSTOCKBDContext();
    

        public EmpaquetadoController()
        {

        }
        // MOSTRAR TODOS LAS CLASES DE EMPAQUETADOS
        [HttpGet]
        [Route("Empaquetado/ObtenerEmpaquetado")]
        public ActionResult<ResultadoApi> Get()
        {
            var resultado = new ResultadoApi();
            resultado.OK = true;
            resultado.Return = db.Empaquetados.ToList();
          
            return resultado;
        }

    }
}
