using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab01.MVC_Hinojosa.Models;

namespace Lab01.MVC_Hinojosa.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            ClsPersona persona = new ClsPersona();
            persona.apellido = "Christian Hinojosa";
            persona.nombres = "Christian Hinojosa";
            persona.email = "christian@gmail.com";
            persona.edad = 25;
            persona.peso = 89.99;
            persona.sexo= false;

            //return View("Index", persona);
            return View(persona);
        }
    }
}