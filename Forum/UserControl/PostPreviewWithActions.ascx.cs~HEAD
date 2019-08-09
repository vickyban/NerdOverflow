using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    /// <summary>
    /// Author: Gia Vien Banh
    /// Post preview user control
    /// </summary>
    public partial class PostPreviewWithActions : System.Web.UI.UserControl
    {
        public delegate void Delegate(string message, bool err);
        /// <summary>
        /// method to content page want this post preview control to trigger after done some changes to the post 
        /// </summary>
        public Delegate Callback { get; set; }
        public Post Post { get; set; }
        public bool IsAuthour
        {
            get
            {
                return Session["UserId"] != null && Convert.ToInt32(Session["UserId"].ToString()) == Post.UserId;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var s = Session["userId"];
            Render();
        }

        /// <summary>
        /// Render controls in the post preview user control with Post detail
        /// </summary>
        private void Render()
        {
            if (Post == null) return;
            lblAuthor.Text = Post.User.Username;
            lblCategory.Text = Post.Category;
            lblPostDate.Text = Post.CreatedAt.ToString();
            postId.Value = Post.PostId.ToString();
            postUrl.NavigateUrl = "/posts/"+ Post.PostId;
            postUrl.Text = Post.Title;
            int count = Post.TotalComments;
            lblComment.Text = count == 1 ? count + " Comment" : count + " Comments";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{postId.Value}/edit");
        }

        protected void btnDelte_Click(object sender, EventArgs e)
        {
            if (int.TryParse(postId.Value, out int id))
            {
                PostRepo.DeletePost(id);
                Callback("Successfully Deleted", false);
            }
        }

        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            Bookmark bookmark = new Bookmark
            {
                PostId = Convert.ToInt32(postId.Value),
                UserId = Convert.ToInt32(Session["UserId"])
            };
            BookmarkRepo.CreateBookmark(bookmark);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", "<script>displayAlert('Successfully Saved' ,false);</script>");
        }
    }
}