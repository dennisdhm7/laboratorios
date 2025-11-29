using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb_Hinojosa.Models;

namespace SistemaWeb_Hinojosa.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Usuario usuario = new Usuario();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string password)
        {
            var rm = usuario.ValidarLogin(Usuario, password);

            if (rm.response)
            {
                rm.href = Url.Content("/Categoria");
            }
            return Json(rm);
        }
        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return RedirectToAction("Index", "Login");
        }
    }
}

