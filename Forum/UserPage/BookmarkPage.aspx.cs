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
    public partial class BookmarkPage : System.Web.UI.Page
    {
        private List<Bookmark> bookmarks = new List<Bookmark>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            this.Master.BookmarkPageBtn.CssClass = "user_right_navlink active";
            bookmarks = getBookmarks("DESC");
            Render();
        }
        public List<Bookmark> getBookmarks(string orderBy)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            return BookmarkRepo.GetBookmarks(userId, orderBy);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy = sortOpt.SelectedValue.Equals("New") ? "DESC" : "ASC";
            List<string> filters = new List<string>();
            if (cbReview.Checked) filters.Add("'review'");
            if (cbPublic.Checked) filters.Add("'public'");
            bookmarks = getBookmarks(orderBy);
            Render();
        }

        private void Render()
        {
            PlaceHolder1.Controls.Clear();
            foreach (var book in bookmarks)
            {
                BookmarkControl control = (BookmarkControl)Page.LoadControl("..\\UserControl\\BookmarkControl.ascx");
                control.Bookmark = book;
                control.Callback = this.Refresh;
                PlaceHolder1.Controls.Add(control);
            }
        }

        public void Refresh(string message, bool err)
        {
            bookmarks = getBookmarks("DESC");
            Render();
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}