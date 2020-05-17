using Physiotherapy.BLL;
using Physiotherapy.BLL.Person;
using Physiotherapy.Common._Resources;
using Physiotherapy.Model;
using Physiotherapy.UIModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    /// <summary>
    /// Register an admin. This class has privacy only member that developer send link
    /// </summary>
    public class RegisterController : Controller
    {
        private readonly static CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.NeutralCultures);

        private static Dictionary<string, string> GetCountryDictionary()
        {
            Dictionary<string, string> countryDct = new Dictionary<string, string>();
            foreach (CultureInfo culture in cinfo)
            {
                if (!string.IsNullOrWhiteSpace(culture.Name))
                    if (!countryDct.ContainsKey(culture.Name))
                        if (culture.Name == "el")
                        {
                            countryDct.Add(culture.Name, String.Join(" - ", culture.DisplayName, culture.NativeName));
                        }
                        else
                            countryDct.Add(culture.Name, culture.DisplayName);
            }
            return countryDct;
        }

        /// <summary>
        /// Initialize Register page for new page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            MemberVO member = new MemberVO();

            ViewBag.SelectCountry = new SelectList(GetCountryDictionary().OrderBy(X => X.Value), "Key", "Value");
            return View(member);
        }

        /// <summary>
        /// Register a new meber.
        /// </summary>
        /// <param name="member">Model member</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MemberVO member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    member.Person.Email = new EmailBL().ConvertAddressToModel(member.Person.Email.Address, member.Person.Email);
                    member.Person.Mobile.IsMobile = true;

                    member.Person.Phone.Phone = member.Person.Phone.Phone.Replace("-", "");
                    member.Person.Mobile.Phone = member.Person.Mobile.Phone.Replace("-", "");
                    if (member.Person.Address.Country == "el")
                    {
                        member.Person.Phone.CodeCountry = "+31";
                        member.Person.Mobile.CodeCountry = "+31";
                    }

                    new MemberBL().AddAdminMember(member);

                    return RedirectToAction("Index", "Home");
                }
                member.Person.Addresses.Add(new AddressVO());
                member.Person.Emails.Add(new EmailVO());
                ViewBag.SelectCountry = new SelectList(GetCountryDictionary().OrderBy(X => X.Value), "Key", "Value");
            }
            catch
            {
                member.Person.Addresses.Add(new AddressVO());
                member.Person.Emails.Add(new EmailVO());
                ViewBag.SelectCountry = new SelectList(GetCountryDictionary().OrderBy(X => X.Value), "Key", "Value");
            }
            return View(member);
        }

        /// <summary>
        /// Login Admin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            MemberVO member;
            string url;
            try
            {
                member = new MemberBL().LoginMember(username, password);

                TempData["UIMsg"] = new UIMessage(Resource.M0001, eUIMsgType.success);
            }
            catch (Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message.ToString(), eUIMsgType.danger);
            }

            if (Request.UrlReferrer != null)
                url = Request.UrlReferrer.ToString();
            else
                url = "/Home/Index";
            return Redirect(url);
        }

        /// <summary>
        /// Sign out a member
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignOut()
        {
            string url;
            try
            {
                MemberStateBL.SignOut();
            }
            catch (Exception ex)
            {
                TempData["UIMsg"] = new UIMessage(ex.Message.ToString(), eUIMsgType.success);
            }
            if (Request.UrlReferrer != null)

                url = Request.UrlReferrer.ToString();
            else
                url = "/Home/Index";
            TempData["UIMsg"] = new UIMessage(Resource.M0002, eUIMsgType.success);
            return Json(new { Url = url });
        }
    }
}