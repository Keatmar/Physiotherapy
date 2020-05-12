using Physiotherapy.BLL;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physiotherapy.Controllers.Organization
{
    /// <summary>
    /// 
    /// </summary>
    public class CvController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            MemberState state = MemberStateBL.State;
            if (state.IsLogin)
            {
                CvVO model = new CvBL().GetCvByMemberId(state.Member.Id);
                return View(model);
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}