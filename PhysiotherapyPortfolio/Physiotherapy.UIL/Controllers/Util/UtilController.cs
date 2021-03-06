﻿using Physiotherapy.BLL;
using Physiotherapy.Common;
using Physiotherapy.Model;
using System;
using System.Web.Mvc;

namespace Physiotherapy.Controllers
{
    /// <summary>
    /// Culture of the site
    /// </summary>
    public class UtilController : Controller
    {
        /// <summary>
        /// Change Application Culture
        /// </summary>
        /// <param name="culture">new culture</param>
        /// <param name="url">Previous Url to redirect</param>
        /// <returns>Redirect to previous url</returns>
        public ActionResult ChangeCulture(string culture, Uri url)
        {
            MemberState state = MemberStateBL.State;
            // Path to Redirect
            try
            {
                // Change Culture
                LocalizationUtil.SetCurrentCulture(culture);
                state.Culture = culture;
            }
            catch
            {
            }
            return Redirect(url.ToString());
        }
    }
}