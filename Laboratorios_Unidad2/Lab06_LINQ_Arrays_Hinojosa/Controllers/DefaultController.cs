using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06_LINQ_Arrays_Hinojosa.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        // 1. fuente de origen de datos
        String[] productos = { "Arroz", "Leche", "Azucar", 
            "Harina", "Atun", "Huevo", "Yogurt", "Jugo", "Gaseosa", "Fideos","Queso"};
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectMany()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());

            var query = productos.ToList();

            //3. Ejecucio de la consulta
            foreach (var producto in query)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }

        public ActionResult ListarProductos()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());

            var query = productos.ToList();

            //3. Ejecucio de la consulta
            foreach (var producto in query)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }

        public ActionResult ListarEnReversa()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());
            String[] productosEnReversa = productos.Reverse().ToArray();
            

            //3. Ejecucio de la consulta
            foreach (var producto in productosEnReversa)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }

        public ActionResult Where1()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());

            var query = from p in productos
                        where p.StartsWith("A")
                        select new { NombreProducto = p };

            //3. Ejecucio de la consulta
            foreach (var producto in query)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }

        public ActionResult Where2()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());

            var query = from p in productos
                        where p.Contains("A")
                        select new { NombreProducto = p };

            //3. Ejecucio de la consulta
            foreach (var producto in query)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }

        public ActionResult Where3()
        {
            //2. Consulta LINQ
            //var query = productos.SelectMany(p => p.ToCharArray());

            var query = from p in productos
                        where p.Length >= 3
                        select new { NombreProducto = p };

            //3. Ejecucio de la consulta
            foreach (var producto in query)
            {
                ViewData["Resultado"] += Convert.ToString(producto) + "\n";
            }
            return View();
        }
    }
}