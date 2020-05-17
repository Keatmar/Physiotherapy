using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Page to not found
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}