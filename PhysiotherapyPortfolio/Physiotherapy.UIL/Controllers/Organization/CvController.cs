using Physiotherapy.BLL;
using Physiotherapy.Model;
using Physiotherapy.Security;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    /// <summary>
    /// Only Admin Member can access
    /// </summary>
    [AdminAuthorize]
    public class CvController : Controller
    {
        /// <summary>
        /// CV Main Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            MemberState state = MemberStateBL.State;
            if (state.IsLogin)
            {
                CvVO model = new CvBL().GetCvByMemberId(state.Member.Id);

                EducationCreateViewBag();
                // Initialize Path
                ViewBag.Path = true;
                Path path = new Path();
                path.InsertMainItemToPath((byte)eMain.Cv);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #region Education
        /// <summary>
        /// Create new Studies
        /// </summary>
        /// <returns></returns>
        public ActionResult EducationCreate()
        {
            MemberState state = MemberStateBL.State;
            EducationVO model = new EducationVO();
            try
            {
                model.MemberId = state.Member.Id;
                model.Member = state.Member;

                ViewBag.Path = true;
                Path path = new Path();
                path.InsertMainItemToPath((byte)eMain.Cv);
                //path.InsertItemToPath((byte)eMain.Cv, Resource.StudiesCreate, "Create");
                path.CreateSessionPath();

            }
            catch
            {
            }
            return PartialView("_EducationCreate",model);
        }

        /// <summary>
        /// Create new studies
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EducationCreate(EducationVO model, FormCollection collection)
        {
            try
            {

                model.Grade = Decimal.Parse(collection["Grade"].ToString().Replace(".",","));
            }
            catch
            {
            }
            return View();
        }

        private Dictionary<string,string> GetAllYearsToNow()
        {
            Dictionary<string, string> years = new Dictionary<string, string>();
            for (int jLoop = 1970; jLoop <= DateTime.Now.Year; jLoop++)
            {
                years.Add(jLoop.ToString(), jLoop.ToString());
            }
            return years;
        }

        private void EducationCreateViewBag()
        {
            Dictionary<string, string> years = GetAllYearsToNow();
            ViewBag.dpYears = new SelectList(years, "Key", "Value",2010);
        }
    }
    #endregion
}