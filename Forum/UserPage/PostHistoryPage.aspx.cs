using Forum.Models;
using Forum.Repositories;
using Forum.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    public partial class PostHistoryPage : System.Web.UI.Page
    {
        private List<Post> posts;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            this.Master.PostPageBtn.CssClass = "user_right_navlink active";
            if (Page.IsPostBack)
            {

            }
            else
            {
                posts = getPosts(new List<string> { "'review'", "'public'" }, "DESC");
                Render();
            }
        }


        public List<Post> getPosts( List<string> filters, string orderBy)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            return PostRepo.getPostsByAuthor(userId, filters, orderBy);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy = sortOpt.SelectedValue.Equals("New") ? "DESC" : "ASC";
            List<string> filters = new List<string>();
            if (cbReview.Checked) filters.Add("'review'");
            if (cbPublic.Checked) filters.Add("'public'");
            posts = getPosts(filters, orderBy);
            Render();
        }

        private void Render()
        {
            PlaceHolder1.Controls.Clear();
            foreach (var post in posts)
            {
                PostPreviewWithActions control = (PostPreviewWithActions)Page.LoadControl("..\\UserControl\\PostPreviewWithActions.ascx");
                control.Post = post;
                PlaceHolder1.Controls.Add(control);
            }
        }
    }
}