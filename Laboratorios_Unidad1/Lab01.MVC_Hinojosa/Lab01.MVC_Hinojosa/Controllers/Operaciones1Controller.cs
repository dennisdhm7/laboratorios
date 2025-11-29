using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab01.MVC_Hinojosa.Models;

namespace Lab01.MVC_Hinojosa.Controllers
{
    public class Operaciones1Controller : Controller
    {
        // GET: Operaciones1
        ClsOperaciones operacion = new ClsOperaciones();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calcular()
        {
            //Recepcionar las variables
            operacion.numero1 = Convert.ToDouble(Request.Form["valor1"]);
            operacion.numero2 = Convert.ToDouble(Request.Form["valor2"]);
            operacion.tipo = Request.Form["tipo"];

            if (operacion.tipo.Equals("S"))
            {
                operacion.resultado = operacion.numero1 + operacion.numero2;
            }

            else if (operacion.tipo.Equals("R"))
            {
                operacion.resultado = operacion.numero1 - operacion.numero2;
            }

            else if (operacion.tipo.Equals("M"))
            {
                operacion.resultado = operacion.numero1 * operacion.numero2;
            }

            else
            {
                if (operacion.numero2 != 0)
                {
                    operacion.resultado = operacion.numero1 / operacion.numero2;
                }
                
            }

            return View(operacion);
        }
    }
}