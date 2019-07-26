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
    public partial class PostHistoryPage : System.Web.UI.Page
    {
        private List<Post> posts;
        protected void Page_Load(object sender, EventArgs e)
        {
            posts = new List<Post>
            {
                 new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math", User = new User { Username = "Shiba Inu" }},
                 new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math", User = new User { Username = "Shiba Inu" }},
                 new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math", User = new User { Username = "Shiba Inu" }},
                 new Post { Title = "I am lazy", CreatedAt = DateTime.Now, Category="Math", User = new User { Username = "Shiba Inu" }}
            };
            foreach(var post in posts)
            {
                PostPreviewWithActions control = (PostPreviewWithActions)Page.LoadControl("..\\UserControl\\PostPreviewWithActions.ascx");
                control.Post = post;
                PlaceHolder1.Controls.Add(control);
            }
        }
    }
}