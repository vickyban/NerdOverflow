using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Forum.Repositories;

namespace Forum.UserControl
{
    public partial class BookmarkControl : System.Web.UI.UserControl
    {
        public Bookmark Bookmark { get; set; }
        public delegate void Delegate(string message, bool err);
        public Delegate Callback { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }
        private void Render()
        {
            if (Bookmark == null) return;
            bookmarkId.Value = Bookmark.BookmarkId.ToString();
            postUrl.NavigateUrl = "/posts/" + Bookmark.PostId;
            lblTitle.Text = Bookmark.Post.Title;
            lblCategory.Text = Bookmark.Post.Category;
            lblAuthor.Text = Bookmark.Post.User.Username;
            lblPostDate.Text = (Bookmark.Post.CreatedAt.ToString());
            int count = Bookmark.Post.TotalComments;
            lblComment.Text = count == 1 ? count + " Comment": count + " Comments" ;
        }

        protected void btnDelte_Click(object sender, EventArgs e)
        {
            int.TryParse(bookmarkId.Value, out int id);
            BookmarkRepo.DeleteBookmark(id);
            Callback("Successfully unsaved", false);
            //Response.Redirect($"/users/{Page.RouteData.Values["Id"].ToString()}/bookmarks/");
        }
    }
}