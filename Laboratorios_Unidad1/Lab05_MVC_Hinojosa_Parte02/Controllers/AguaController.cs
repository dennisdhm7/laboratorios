using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab05_MVC_Hinojosa.Models;

namespace Lab05_MVC_Hinojosa.Controllers
{
    public class AguaController : Controller
    {
        int cuota = 40;
        // GET: Agua
        public ActionResult Index(ClsAgua objAgua)
        {
            if (objAgua.litros > 200)
            {
                cuota += (objAgua.litros - 200) * 2;
                objAgua.litros -= (cuota - 40) / 2;
            }
            if (objAgua.litros >= 50 && objAgua.litros <= 200)
            {
                cuota += objAgua.litros - 49;
            }
            ViewBag.Cuota = cuota;

            return View();
        }
    }
}