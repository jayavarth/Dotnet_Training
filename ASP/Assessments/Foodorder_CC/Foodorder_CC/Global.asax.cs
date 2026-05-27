using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Foodorder_CC
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Visitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["Visitors"] = (int)Application["Visitors"] + 1;
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] + 1;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] - 1;
        }
    }
}
