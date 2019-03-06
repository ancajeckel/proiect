using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LibraryWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                bool notfound;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        notfound = true;
                        break;
                    default:
                        notfound = false;
                        break;
                }
                Server.ClearError();
                if (notfound)
                    this.Response.RedirectToRoute("Default", new { controller = "Home", action = "NotFound" });
                else
                    this.Response.RedirectToRoute("Default", new { controller = "Home", action = "Error" });
            }

        }
    }
}
