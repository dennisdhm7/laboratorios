using Lab01.MVC_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Lab01.MVC_Hinojosa.Controllers
{
    public class Operaciones2Controller : Controller
    {
        // GET: Operaciones2
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calcular(ClsOperaciones operacion) 
        {

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