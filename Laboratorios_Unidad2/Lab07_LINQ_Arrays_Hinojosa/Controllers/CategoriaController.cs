using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab07_LINQ_Arrays_Hinojosa.Models;

namespace Lab07_LINQ_Arrays_Hinojosa.Controllers
{
    public class CategoriaController : Controller
    {
        private Categoria objCategoria = new Categoria();

        // GET: Categoria
        public ActionResult Index()//Listar
        {
            return View(objCategoria.Listar());
        }

        public ActionResult Consulta1()//Listar
        {
            return View(objCategoria.Consulta1());
        }
    }
}