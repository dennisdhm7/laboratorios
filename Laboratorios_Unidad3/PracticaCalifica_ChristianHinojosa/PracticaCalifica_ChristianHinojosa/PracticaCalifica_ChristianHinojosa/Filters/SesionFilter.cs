using System.Web.Mvc;

namespace PracticaCalifica_ChristianHinojosa.Filters
{
    public class SesionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
            }
        }
    }
}
