using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Forum
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            //string id = Page.RouteData.Values["Id"].ToString();
            routeCollection.MapPageRoute("RouteForUser", "users/{Id}", "~/Customer.aspx");
            routeCollection.MapPageRoute("RouteForPost", "posts/{Id}", "~/Customer.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}