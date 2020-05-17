using Physiotherapy.Common;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Physiotherapy
{
    /// <summary>
    /// Physiotherapy App started
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application Start and initialize Resource Factory
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //  Init Culture
            LocalizationUtil.Init(ConfigurationManager.AppSettings["DefCulture"],
                                 ConfigurationManager.AppSettings["DefCountryCode"],
                                 ConfigurationManager.AppSettings["DefCurrencySymbolCode"],
                                 ConfigurationManager.AppSettings["DefaultCurrencySymbol"]);
        }
    }
}