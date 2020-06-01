using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Physiotherapy.BLL;
using Physiotherapy.Common._Resources;
using Physiotherapy.Model;
using Physiotherapy.Security;
using Physiotherapy.UIModel;

namespace Physiotherapy.Controllers.Account
{
    [SuperUserAuthorize]
    public class AdminController : Controller
    {
        private const string UrlPattern = @"^http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";

        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        /// <summary>
        /// Check and save url
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Admin(FormCollection collection)
        {
            UrlVO model = new UrlVO();
            try
            {
                model.Url = FixUrl(collection["Url"]);
                model.CreationDate = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).Date;
                model.ExpireDate = model.CreationDate.AddDays(7);
                model.GUID = Guid.NewGuid().ToString();
                new AdminBL().Save(model);
                return RedirectToAction("UrlDetails", new { model.Url });
            }
            catch (Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
                return RedirectToAction("Admin");
            }
        }

        /// <summary>
        /// Get Details by url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ActionResult UrlDetails(string url)
        {
            UrlVO model = new UrlVO();
            try
            {
                model = new AdminBL().GetUrlByUrl(url);
            }
            catch (Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message, eUIMsgType.danger);
                return RedirectToAction("Admin");
            }
            return View(model);
        }

        /// <summary>
        /// fix url to have correct form
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string FixUrl(string url)
        {
            try
            {
                if (!url.ToLower().Contains("localhost"))
                {
                    Regex rx = new Regex(UrlPattern);
                    if (!rx.IsMatch(url))
                        throw new Exception(Resource.UrlIsNotCorrect);
                }
                url = url.Replace("www", "");
                url = url.Replace("http", "");
                url = url.Replace("https", "");
            }
            catch
            {
                throw;
            }
            return url;
        }
    }
}