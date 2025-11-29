using SistemaWeb_Hinojosa.Filters;
using SistemaWeb_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb_Hinojosa.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Login
        [NoLogin]
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
            return Redirect("~/Login");
        }
    }
}
