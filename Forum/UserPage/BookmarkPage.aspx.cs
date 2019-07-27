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
    public partial class BookmarkPage : System.Web.UI.Page
    {
        private List<Bookmark> bookmarks = new List<Bookmark>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            bookmarks= getBookmarks(userId);

            foreach(var book in bookmarks)
            {
                BookmarkControl control = (BookmarkControl)Page.LoadControl("..\\UserControl\\BookmarkControl.ascx");
                control.Bookmark = book;
                PlaceHolder1.Controls.Add(control);             
            }
        }
        public List<Bookmark> getBookmarks(int userId)
        {
            return BookmarkRepo.GetBookmarks(userId);
        }
    }
}