using Physiotherapy.BLL;
using Physiotherapy.Common._Resources;
using Physiotherapy.Model;
using Physiotherapy.Security;
using Physiotherapy.UIModel;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
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
            CvVO model = new CvVO();
            try
            {
                if (state.IsLogin)
                {
                    model = new CvBL().GetCvByMemberId(state.Member.Id);
                    EducationCreateViewBag();
                    Task<List<EducationVO>> tEducations = Task.Run(() => new EducationBL().GetEducationsByMemberId(state.Member.Id));
                    Task.WaitAll(tEducations);
                    model.Educations = tEducations.Result;
                    // Initialize Path
                    ViewBag.Path = true;
                    Path path = new Path();
                    path.InsertMainItemToPath((byte)eMain.Cv);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
            }
            return View(model);
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
                model.Grade = Decimal.Parse(collection["Grade"].Replace(".",","));
                model = new EducationBL().Save(model);
            }
            catch(Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
                return RedirectToAction("Index");
            }
            TempData["UIMsg"] = new UIMessage(Resource.M0003, eUIMsgType.success);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit education with this id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EducationEdit(int id)
        {
            MemberState state = MemberStateBL.State;
            EducationVO model = new EducationVO();
            try
            {
                IEducationBL bl = new EducationBL();
                model = bl.GetEducationById(id);
                if (model.MemberId != state.Member.Id)
                    throw new AuthenticationException(Resource.NotAuthorized);
                EducationCreateViewBag();
                return PartialView("_EducationEdit", model);
            }
            catch (AuthenticationException ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
                return Json(new { error = true, message = ex.Message});
            }
            catch(Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
                return Json(new { error = true, message = ex.Message });
            }
        }

        /// <summary>
        /// Update Education
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateEducation(EducationVO model, FormCollection collection)
        {
            try
            {
                IEducationBL bl = new EducationBL();
                bl.Save(model);
            }
            catch(Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
            }
            return RedirectToAction("Index");

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