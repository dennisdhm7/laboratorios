using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab04.MVC_Chite.Models;

namespace Lab04.MVC_Chite.Controllers
{
    public class EncuestaController : Controller
    {
        private static ClsEncuesta encuesta = new ClsEncuesta(); 
        // GET: Encuesta
        public ActionResult Index()
        {
            return View(encuesta);
        }

        [HttpPost]
        public ActionResult Votar(ClsEncuesta model)
        {
            if (ModelState.IsValid)
            {
                if (encuesta.Votos.ContainsKey(model.OpcionSeleccionada))
                {
                    encuesta.Votos[model.OpcionSeleccionada]++;
                }
            }
            return RedirectToAction("Resultados");
        }

        public ActionResult Resultados() 
        { 
            int total = encuesta.Votos.Values.Sum();
            ViewBag.Total = total;

            var porcentajes = encuesta.Votos.ToDictionary(v => v.Key, v => total == 0 ? 0 : (v.Value * 100)/ total);

            ViewBag.Porcentajes = porcentajes;

            return View(encuesta);
        }
    }
}