using Physiotherapy.BLL;
using Physiotherapy.Model;
using Physiotherapy.Security;
using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    /// <summary>
    /// Only Admin Member can acccess
    /// </summary>
    [AdminAuthorize]
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

                // Initialize Path
                ViewBag.Path = true;
                Path path = new Path();
                path.InsertMainItemToPath((byte)eMain.Cv);
                return View(model);
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}