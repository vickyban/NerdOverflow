using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    /// <summary>
    /// Author: Gia Vien Banh
    /// </summary>
    public partial class UserPageMaster : System.Web.UI.MasterPage
    {
        public Button ProfilePageBtn { get => btnProfileLink; }
        public Button BookmarkPageBtn { get => btnBookmarkLink; }
        public Button PostPageBtn { get => btnPostsLink; }
        public int UserId
        {
            get
            {
                // attempt to get the userId from the url paramemter /users/{Id}
                if (int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId))
                    return userId;
                else { return 0; }
            }
        }
        public User User;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Protected route, if the user is not login, redirect to home page
            if(Session["UserId"] == null)
            {
                Response.Redirect("/");
                return;
            }
            int.TryParse(Session["UserId"].ToString(), out int curId);
            if( curId == UserId)  // the user access his profile
            {
                User = UserRepo.GetUser(curId);
                Render();
            }
            else // else if the user try to access someone else 's profile , redirect to his profile instead
            {
                Response.Redirect($"/users/{curId}/posts/");
            }
        
        }
        /// <summary>
        /// Redirect to user's profile page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProfileLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/";
            Response.Redirect(url);
        }
        /// <summary>
        /// Redirect to the user's bookmarks page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBookmarkLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/bookmarks/";
            Response.Redirect(url);
        }
        /// <summary>
        /// Redirect to user's posts page when linking on the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnPostsLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/posts/";
            Response.Redirect(url);
        }

        /// <summary>
        ///  Render controls in the master page with the user info
        /// </summary>
        private void Render()
        {
            if (User == null) return;
            lblUsername.Text = User.Username;
            lblCreatedDate.Text = $"Joined on {User.CreatedAt.ToShortDateString()}";
            if (User.Profile_img != null)  // if user has a profile image then load it
                imgProfile.ImageUrl = "data:image;base64," + Convert.ToBase64String(User.Profile_img);
            else // else use the serve default profile image
                imgProfile.ImageUrl = "~\\Images\\default.png";
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