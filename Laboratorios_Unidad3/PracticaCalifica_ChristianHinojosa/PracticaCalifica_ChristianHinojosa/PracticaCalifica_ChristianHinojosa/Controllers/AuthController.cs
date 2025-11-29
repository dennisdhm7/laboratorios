using System.Linq;
using System.Web.Mvc;
using PracticaCalifica_ChristianHinojosa.Models;

namespace PracticaCalifica_ChristianHinojosa.Controllers
{
    public class AuthController : Controller
    {
        private ConsejeriaContext db = new ConsejeriaContext();

        // GET: Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Complete los campos.";
                return View(model);
            }

            // Buscar usuario real en BD
            var user = db.Usuarios
                .FirstOrDefault(u => u.Correo == model.Correo && u.Password == model.Password);

            if (user == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View(model);
            }

            // Crear sesión
            Session["usuario"] = user.Correo;
            Session["rol"] = user.Rol;

            // Redirección según rol
            return RedirectToAction("Dashboard", "Docentes");
        }

        // Cerrar sesión
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
