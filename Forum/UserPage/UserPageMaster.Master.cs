using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    public partial class UserPageMaster : System.Web.UI.MasterPage
    {
        public Button ProfilePageBtn { get => btnProfileLink; }
        public Button BookmarkPageBtn { get => btnBookmarkLink; }
        public Button PostPageBtn { get => btnPostsLink; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnProfileLink_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["Id"].ToString();
            string url = $"/users/{id}/";
            Response.Redirect(url);
        }

        protected void btnBookmarkLink_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["Id"].ToString();
            string url = $"/users/{id}/bookmarks/";
            Response.Redirect(url);
        }

        protected void btnPostsLink_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["Id"].ToString();
            string url = $"/users/{id}/posts/";
            Response.Redirect(url);
        }
    }
}