using Lab06_LINQ_Arrays_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06_LINQ_Arrays_Hinojosa.Controllers
{
    public class ProductoPrecioController : Controller
    {
        // GET: ProductoPrecio
        // 1. fuente de origen de datos
        String[] productos = { "Arroz", "Leche", "Azucar",
            "Harina", "Atun", "Huevo", "Yogurt", "Jugo", "Gaseosa","Aceite", "Fideos","Queso"};

        double[] costo = { 5.5, 3.5, 4, 4.8, 6, 12, 6.5, 5, 9.5, 8.5, 3.2, 20 };
        public ActionResult Index(ClsProductoPrecio objProducto)
        {
            string[] productos = { "Arroz", "Leche", "Azucar", "Harina", "Atun", "Huevo", "Yogurt", "Jugo", "Gaseosa", "Aceite", "Fideos", "Queso" };
            double[] costo = { 5.5, 3.5, 4, 4.8, 6, 12, 6.5, 5, 9.5, 8.5, 3.2, 20 };

            string busqueda = objProducto.busqueda;

            var lista =
                productos
                .Select((producto, index) => new { producto, index })
                .Join(
                    costo.Select((precio, index) => new { precio, index }),
                    p => p.index,
                    c => c.index,
                    (p, c) => new { p.producto, c.precio }
                );

            if (!string.IsNullOrEmpty(busqueda))
            {
                lista = lista.Where(x => x.producto.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            objProducto.resultado = string.Join("\n", lista.Select(x => $"{x.producto}: ${x.precio}"));

            return View(objProducto);
        }


    }
}