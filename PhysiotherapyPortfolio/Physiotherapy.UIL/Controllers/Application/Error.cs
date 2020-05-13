using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    public class Error : Controller
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