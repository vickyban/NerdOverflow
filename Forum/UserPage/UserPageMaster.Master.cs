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
    public partial class UserPageMaster : System.Web.UI.MasterPage
    {
        public Button ProfilePageBtn { get => btnProfileLink; }
        public Button BookmarkPageBtn { get => btnBookmarkLink; }
        public Button PostPageBtn { get => btnPostsLink; }
        public int UserId
        {
            get
            {
                if (int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId))
                    return userId;
                else { return 0; }
            }
        }
        public User User;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userId"] == null)
            {
                Response.Redirect("~\\WebForm1.aspx");
                return;
            }
            int.TryParse(Session["userId"].ToString(), out int curId);
            if( curId == UserId)
            {
                User = UserRepo.GetUser(curId);
                Render();
            }
            else
            {
                Response.Redirect($"/users/{curId}/posts/");
            }
        
        }

        protected void btnProfileLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/";
            Response.Redirect(url);
        }

        protected void btnBookmarkLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/bookmarks/";
            Response.Redirect(url);
        }

        protected void btnPostsLink_Click(object sender, EventArgs e)
        {
            string url = $"/users/{UserId}/posts/";
            Response.Redirect(url);
        }

        private void Render()
        {
            if (User == null) return;
            lblUsername.Text = User.Username;
            lblCreatedDate.Text = $"Joined on {User.CreatedAt.ToShortDateString()}";
            if (User.Profile_img != null)
                imgProfile.ImageUrl = "data:image;base64," + Convert.ToBase64String(User.Profile_img);
            else
                imgProfile.ImageUrl = "~\\Images\\default.png";
        }
    }
}