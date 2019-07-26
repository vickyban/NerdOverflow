using Forum.Models;
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
            bookmarks = new List<Bookmark>
            {
                new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math"},
                    User = new User { Username = "Shiba Inu" }
                },
                new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy2", CreatedAt = DateTime.Now, Category="Food"},
                    User = new User { Username = "Shiba Inu" }
                },
                 new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math"},
                    User = new User { Username = "Shiba Inu" }
                },
                new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy2", CreatedAt = DateTime.Now, Category="Food"},
                    User = new User { Username = "Shiba Inu" }
                },
                 new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math"},
                    User = new User { Username = "Shiba Inu" }
                },
                new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy2", CreatedAt = DateTime.Now, Category="Food"},
                    User = new User { Username = "Shiba Inu" }
                },
                 new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math"},
                    User = new User { Username = "Shiba Inu" }
                },
                new Bookmark
                {
                    BookmarkId = 1,
                    Post = new Post { Title = "I am lazy2", CreatedAt = DateTime.Now, Category="Food"},
                    User = new User { Username = "Shiba Inu" }
                },
            };

            foreach(var book in bookmarks)
            {
                BookmarkControl control = (BookmarkControl)Page.LoadControl("..\\UserControl\\BookmarkControl.ascx");
                control.Bookmark = book;
                PlaceHolder1.Controls.Add(control);             
            }
        }
    }
}