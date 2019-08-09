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
    /// <summary>
    /// Author: Gia Vien Banh
    /// </summary>
    public partial class PostHistoryPage : System.Web.UI.Page
    {
        private List<Post> Posts;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            this.Master.PostPageBtn.CssClass = "user_right_navlink active";
            Posts = getPosts(new List<string> { "'review'", "'published'" }, "DESC");
            Render();
        }


        public List<Post> getPosts( List<string> filters, string orderBy)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            return PostRepo.getPostsByAuthor(userId, filters, orderBy);
        }
        /// <summary>
        /// Handle filter posts event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy = sortOpt.SelectedValue.Equals("New") ? "DESC" : "ASC";
            List<string> filters = new List<string>();
            if (cbReview.Checked) filters.Add("'review'");
            if (cbPublic.Checked) filters.Add("'published'");
            Posts = getPosts(filters, orderBy);
            Render();
        }

        /// <summary>
        /// Render controls in the placeholder
        /// </summary>
        private void Render()
        {
            PlaceHolder1.Controls.Clear();
            foreach (var post in Posts)
            {
                PostPreviewWithActions control = (PostPreviewWithActions)Page.LoadControl("..\\UserControl\\PostPreviewWithActions.ascx");
                control.Post = post;
                control.Callback = this.Refresh;
                PlaceHolder1.Controls.Add(control);
            }
        }

        /// <summary>
        /// Re render post preveiew controls in the placeholders  
        /// </summary>
        /// <param name="message"></param>
        /// <param name="err"></param>
        public void Refresh(string message, bool err)
        {
            Posts = getPosts(new List<string> { "'review'", "'published'" }, "DESC");
            Render();
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}