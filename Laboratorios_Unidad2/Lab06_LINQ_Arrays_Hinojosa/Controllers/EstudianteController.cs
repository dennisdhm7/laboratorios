using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab06_LINQ_Arrays_Hinojosa.Models;

namespace Lab06_LINQ_Arrays_Hinojosa.Controllers
{
    public class EstudianteController : Controller
    {
        // Datos de ejemplo
        string[] estudiante = { "Sebastian", "Brant", "Lisbeth", "Christian", "Piero", "Fabiola", "Erlan", "Mario", "Cesar", "Andree" };
        double[] nota = { 4.8, 10, 11, 9.99, 20, 15, 8, 13, 11.5, 5 };

        // GET: Estudiante
        public ActionResult Index(string busqueda)
        {
            var query = (from e in estudiante.Select((nombreEstudiante, index) => new { nombreEstudiante, index })
                         join n in nota.Select((valorNota, index) => new { valorNota, index })
                         on e.index equals n.index
                         select new { e.nombreEstudiante, n.valorNota }).ToList();

            List<ClsEstudiante> ListaE = new List<ClsEstudiante>();
            foreach (var item in query)
            {
                ClsEstudiante estudiante = new ClsEstudiante();
                estudiante.Nombre = item.nombreEstudiante;
                estudiante.Nota = item.valorNota;

                if (estudiante.Nota > 10.5)
                {
                    estudiante.Condicion = "Aprobado";
                }
                else
                {
                    estudiante.Condicion = "Desaprobado";
                }
                ListaE.Add(estudiante);
            }

            
            if (!string.IsNullOrEmpty(busqueda))
            {
                ListaE = ListaE
                         .Where(e => e.Nombre.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                         .ToList();
            }

            return View(ListaE);
        }
    }
}
