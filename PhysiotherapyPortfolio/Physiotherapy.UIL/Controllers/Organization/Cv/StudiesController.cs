using Physiotherapy.BLL;
using Physiotherapy.Model;
using System.Web.Mvc;

namespace Physiotherapic.Controllers.Organization.Cv
{
    /// <summary>
    /// Studies for member's cv
    /// </summary>
    public class StudiesController : Controller
    {
        /// <summary>
        /// Create new Studies
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            MemberState state = MemberStateBL.State;
            StudiesVO model = new StudiesVO();
            try
            {
                model.MemberId = state.Member.Id;
                model.Member = state.Member;

                ViewBag.Path = true;
                Path.InitializePath((byte)eMain.Cv);
            }
            catch
            {
            }
            return View(model);
        }

        /// <summary>
        /// Create new studies
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(StudiesVO model, FormCollection collection)
        {
            try
            {
            }
            catch
            {
            }
            return View();
        }

        /// <summary>
        /// Display studies
        /// </summary>
        /// <param name="Id">Studies' id to be changed</param>
        /// <returns></returns>
        public ActionResult Display(int Id)
        {
            MemberState state = MemberStateBL.State;
            StudiesVO model = new StudiesVO();
            try
            {
                model.MemberId = state.Member.Id;
                model.Member = state.Member;
            }
            catch
            {
            }
            return View(model);
        }

        /// <summary>
        /// Edit studies
        /// </summary>
        /// <param name="Id">Studies' id to be changed</param>
        /// <returns></returns>
        public ActionResult Edit(int Id)
        {
            MemberState state = MemberStateBL.State;
            StudiesVO model = new StudiesVO();
            try
            {
                model.MemberId = state.Member.Id;
                model.Member = state.Member;
            }
            catch
            {
            }
            return View(model);
        }

        /// <summary>
        /// Edit studies
        /// </summary>
        /// <param name="model">New studies' data</param>
        /// <param name="collection">data</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Edit(StudiesVO model, FormCollection collection)
        {
            try
            {
            }
            catch
            {
            }
            return View();
        }

        /// <summary>
        /// Delete studies
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Delete(int Id)
        {
            MemberState state = MemberStateBL.State;
            StudiesVO model = new StudiesVO();
            try
            {
                model.MemberId = state.Member.Id;
                model.Member = state.Member;
            }
            catch
            {
            }
            return View(model);
        }

        /// <summary>
        /// Delete studies
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(StudiesVO model, FormCollection collection)
        {
            try
            {
            }
            catch
            {
            }
            return View();
        }
    }
}