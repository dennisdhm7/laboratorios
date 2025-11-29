using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Lab05.MVC_Chite.Models;

namespace Lab05.MVC_Chite.Controllers
{
    public class PositivoController : Controller
    {
        public List<int> numeros = new List<int>();
        // GET: Positivo
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Separar (ClsPositivos objPositivo)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Request.Form["value" + i] != "" && !Regex.IsMatch(Request.Form["value" + i], @"[a-aA-Z]"))
                {
                    numeros.Add(Convert.ToInt32(Request.Form["value" + i]));
                }
            }

            foreach (int item in numeros)
            {
                if (item >= 0)
                {
                    objPositivo.numerosPositivos.Add(item);
                }
                else
                {
                    objPositivo.numerosNegativos.Add(item);
                }
            }
            return View(objPositivo);
        }
    }
}