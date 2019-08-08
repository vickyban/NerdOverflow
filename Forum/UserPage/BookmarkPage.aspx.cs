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
        public int UserId
        {
            get
            {
                if (int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId))
                    return userId;
                else
                    return 0;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.BookmarkPageBtn.CssClass = "user_right_navlink active";
            bookmarks = BookmarkRepo.GetBookmarks(UserId, "DESC");
            Render();
        }

        /// <summary>
        /// Handle filter bookmarks event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy = sortOpt.SelectedValue.Equals("New") ? "DESC" : "ASC";
            List<string> filters = new List<string>();
            if (cbReview.Checked) filters.Add("'review'");
            if (cbPublic.Checked) filters.Add("'public'");
            bookmarks = BookmarkRepo.GetBookmarks(UserId, orderBy);
            Render();
        }

        /// <summary>
        /// Render list of bookmarks into the placeholder 
        /// </summary>
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

        /// <summary>
        /// Render the list of bookmarks into the placeholder
        /// </summary>
        /// <param name="message">message to be display after rerender the list of bookmarks</param>
        /// <param name="err">indicate if message is an error message or not</param>
        public void Refresh(string message, bool err)
        {
            bookmarks = BookmarkRepo.GetBookmarks(UserId, "DESC");
            Render();
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}