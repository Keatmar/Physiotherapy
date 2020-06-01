using Physiotherapy.BLL;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Physiotherapy.Security
{
    /// <summary>
    /// Admin Security
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Allow Access only member with role admin who has login to app
        /// </summary>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!MemberStateBL.State.IsLogin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "NotAuthorized", controller = "Error" }));
            }
        }
    }

    /// <summary>
    /// Super User Security
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SuperUserAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Allow Access only super user
        /// </summary>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!MemberStateBL.State.IsSuperUser)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "NotAuthorized", controller = "Error" }));
            }
        }
    }
}