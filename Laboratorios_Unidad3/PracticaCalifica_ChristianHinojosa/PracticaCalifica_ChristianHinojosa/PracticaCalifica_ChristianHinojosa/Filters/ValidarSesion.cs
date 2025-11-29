using System.Web.Mvc;

namespace PracticaCalifica_ChristianHinojosa.Filters
{
    public class ValidarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = filterContext.HttpContext.Session["usuario"];

            if (usuario == null)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
