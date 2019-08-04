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
            routeCollection.MapPageRoute("RouteForUserProfile", "users/{Id}/", "~/UserPage/ProfilePage.aspx");
            routeCollection.MapPageRoute("RouteForPost", "posts/{Id}", "~/Customer.aspx");
            routeCollection.MapPageRoute("RouteForPosts", "posts/", "~/PostsPage/PostListPage.aspx");

            routeCollection.MapPageRoute("RouteForBookmarks", "users/{Id}/bookmarks/", "~/UserPage/BookmarkPage.aspx");
            routeCollection.MapPageRoute("RouteForPostHistory", "users/{Id}/posts/", "~/UserPage/PostHistoryPage.aspx");
            //routeCollection.MapPageRoute("RouteForPost", "users/{Id}", "~/UserPage/Customer.aspx");

        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
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