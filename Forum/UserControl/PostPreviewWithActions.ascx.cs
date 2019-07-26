using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    public partial class PostPreviewWithActions : System.Web.UI.UserControl
    {
        public Post Post { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (Post == null) return;
            lblAuthor.Text = Post.User.Username;
            lblCategory.Text = Post.Category;
            lblPostDate.Text = Post.CreatedAt.ToString();
            lblTitle.Text = Post.Title;
            postId.Value = Post.PostId.ToString();
            postUrl.NavigateUrl = "/posts/"+postId;
            int count = Post.TotalComments;
            lblComment.Text = count == 1 ? count + " Comment" : count + " Comments";
        }
    }
}