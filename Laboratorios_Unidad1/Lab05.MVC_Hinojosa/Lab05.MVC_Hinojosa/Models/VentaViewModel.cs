using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab05.MVC_Chite.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Seleccionado { get; set; }
        public string ImageUrl { get; set; }

        public class VentaViewModel
        {
            [Required(ErrorMessage = "Debe Seleccionar al menos un producto")]
            public List<Producto> Productos { get; set; }
            public decimal Subtotal { get; set; }
            public decimal IGV { get; set; }
            public decimal Total { get; set; }
            public VentaViewModel()
            {
                Productos = new List<Producto>();


            }
            public void CalcularTotales()
            {
                Subtotal = Productos.Where(p => p.Seleccionado).Sum(p => p.Precio);
                IGV = Subtotal * 0.18m;
                Total = Subtotal + IGV;
            }

        }
    }
}