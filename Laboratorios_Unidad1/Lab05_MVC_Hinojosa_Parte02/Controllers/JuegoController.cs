using Lab05_MVC_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05_MVC_Hinojosa.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerarJuego(ClsJuego objJuego)
        {
            Random rnd = new Random();
            objJuego.numero1 = rnd.Next(3);
            objJuego.numero2 = rnd.Next(3);
            objJuego.numero3 = rnd.Next(3);

            if ((objJuego.numero1 == objJuego.numero2) &&
                (objJuego.numero2 == objJuego.numero3))
            {
                objJuego.Resultado = "Ganaste S/ 1,000";
            }
            else if ((objJuego.numero1 == objJuego.numero2) ||
                     (objJuego.numero2 == objJuego.numero3) ||
                     (objJuego.numero1 == objJuego.numero3))
            {
                objJuego.Resultado = "Ganaste 1 intento más";
            }
            else
            {
                objJuego.Resultado = "Sigue invirtiendo, ya estás cerca de ganar";
            }

            return View(objJuego);
        }
    }
}