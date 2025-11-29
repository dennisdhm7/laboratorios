using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab07_LINQ_Arrays_Hinojosa.Models;

namespace Lab07_LINQ_Arrays_Hinojosa.Controllers
{
    public class HeladoController : Controller
    {
        Helado objhelado = new Helado();

        // GET: Helado
        public ActionResult Index()
        {
            return View(objhelado.Listar());
        }

        public ActionResult ListarHeladoCategoria()
        {
            return View(objhelado.ListarHeladoCategoria());
        }
    }
}