using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02.MVC_Chite.Models;

namespace Lab02.MVC_Chite.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarUno()
        {
            ClsPersona persona = new ClsPersona();
            persona.nombre = "Luis";
            persona.apellido = "Castro Cabrera";
            persona.email = "lcastro@gmail.com";
            persona.edad= 18;
            persona.estatura = 1.75;
            persona.soltero = true;
            return View(persona);
        }

        public ActionResult MostrarTodos()
        {
            List<ClsPersona> Lista = new List<ClsPersona>();
            ClsPersona persona1 = new ClsPersona();
            persona1.nombre = "Luis";
            persona1.apellido = "Castro Cabrera";
            persona1.email = "lcastro@gmail.com";
            persona1.edad = 18;
            persona1.estatura = 1.75;
            persona1.soltero = true;
            Lista.Add(persona1);

            ClsPersona persona2 = new ClsPersona();
            persona2.nombre = "Julia Martha";
            persona2.apellido = "Gomez Quiroz";
            persona2.email = "jgomez@gmail.com";
            persona2.edad = 20;
            persona2.estatura = 1.65;
            persona2.soltero = true;
            Lista.Add(persona2);

            ClsPersona persona3 = new ClsPersona();
            persona3.nombre = "Sebastian";
            persona3.apellido = "Arce Bracamonte";
            persona3.email = "sebas@upt.pe";
            persona3.edad = 23;
            persona3.estatura = 1.76;
            persona3.soltero = true;
            Lista.Add(persona3);

            ClsPersona persona4 = new ClsPersona();
            persona4.nombre = "Lisbeth";
            persona4.apellido = "Espinoza Caso";
            persona4.email = "li2565245656@virtual.upt.pe";
            persona4.edad = 25;
            persona4.estatura = 1.77;
            persona4.soltero = true;
            Lista.Add(persona4);

            ClsPersona persona5 = new ClsPersona();
            persona5.nombre = "Brian";
            persona5.apellido = "Chite Quispe";
            persona5.email = "brianchite@virtual.upt.pe";
            persona5.edad = 22;
            persona5.estatura = 1.68;
            persona5.soltero = false;
            Lista.Add(persona5);

            ClsPersona persona6 = new ClsPersona();
            persona6.nombre = "Jaime";
            persona6.apellido = "Flores Quispe";
            persona6.email = "jflores@upt.edu.e";
            persona6.edad = 23;
            persona6.estatura = 1.71;
            persona6.soltero = false;
            Lista.Add(persona6);

            return View(Lista);
        }
    }
}