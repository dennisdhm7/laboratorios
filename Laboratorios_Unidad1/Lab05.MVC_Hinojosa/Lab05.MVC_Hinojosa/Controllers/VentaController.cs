using Lab05.MVC_Chite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Lab05.MVC_Chite.Models.Producto;

namespace Lab05.MVC_Chite.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        private static List<Producto> productosDisponibles = new
            List<Producto>()
        {
            new Producto{Id=1, Nombre="Laptop" , Precio =2500, ImageUrl="~/Content/Imagenes/laptop.jpg"},
            new Producto{Id=1, Nombre="Impresora" , Precio =700, ImageUrl="~/Content/Imagenes/laptop.jpg"},
            new Producto{Id=1, Nombre="Teclado" , Precio =250, ImageUrl="~/Content/Imagenes/laptop.jpg"},
            new Producto{Id=1, Nombre="Mouse" , Precio =150, ImageUrl="~/Content/Imagenes/laptop.jpg"}
        };
        // GET: Venta
        public ActionResult Index()
        {
            var model = new VentaViewModel()
            {
                Productos = productosDisponibles.Select(p => new Producto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Seleccionado = false
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(VentaViewModel model) 
        { 
            if (model.Productos ==null || !model.Productos.Any(productosDisponibles => productosDisponibles.Seleccionado))
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto.");
                return View(model);
            }
            return View("Resultado", model);
        }
    }
}