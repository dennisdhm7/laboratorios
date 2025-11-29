using Lab05_MVC_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Lab05_MVC_Hinojosa.Models.Producto;

namespace Lab05_MVC_Hinojosa.Controllers
{
    public class VentaController : Controller
    {
        // Lista de productos disponibles con IDs únicos
        private static List<Producto> productosDisponibles = new List<Producto>()
        {
            new Producto{Id=1, Nombre="Laptop" , Precio =2500, ImagenUrl="~/Content/Imagenes/laptop.jpg"},
            new Producto{Id=2, Nombre="Impresora" , Precio =700, ImagenUrl="~/Content/Imagenes/impresora.jpg"},
            new Producto{Id=3, Nombre="Teclado" , Precio =250, ImagenUrl="~/Content/Imagenes/teclado.jpg"},
            new Producto{Id=4, Nombre="Mouse" , Precio =150, ImagenUrl="~/Content/Imagenes/mouse.jpg"},
            new Producto{Id=4, Nombre="Monitor" , Precio =150, ImagenUrl="~/Content/Imagenes/monitor.jpg"}
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
                    Seleccionado = false,
                    ImagenUrl = p.ImagenUrl
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(VentaViewModel model)
        {

            if (model.Productos == null || !model.Productos.Any(p => p.Seleccionado))
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto.");
                return View(model);
            }


            var productosConImagen = productosDisponibles.Select(p => new Producto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                Seleccionado = model.Productos.FirstOrDefault(x => x.Id == p.Id)?.Seleccionado ?? false
            }).ToList();

            model.Productos = productosConImagen;


            model.CalcularTotales();

            return View("Resultado", model);
        }
    }
}