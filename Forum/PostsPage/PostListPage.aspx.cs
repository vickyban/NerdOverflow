using Forum.Models;
using Forum.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.PostsPage
{
    public partial class PostListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Post p = new Post
            {
                Title = " Hdjsfs dfa gda",
                Content = "A quick and simplified answer is that Lorem Ipsum refers to text that the DTP (Desktop Publishing) industry use as replacement text when the real text is not available." +
    "For example, " +
    "when designing a brochure or book," +
    "a designer will insert Lorem ipsum text if the real text is not available. The Lorem ipsum text looks real enough that the brochure or book looks complete. The book or brochure can be shown to the client for approval.",
                Category = "animal",
                User = new User
                {
                    Username = "dfds",
                }
            };
            PostPreviewWithActions c = (PostPreviewWithActions)Page.LoadControl("~\\UserControl\\PostPreviewWithActions.ascx");
            PostPreviewWithActions c1 = (PostPreviewWithActions)Page.LoadControl("~\\UserControl\\PostPreviewWithActions.ascx");
            PostPreviewWithActions c2 = (PostPreviewWithActions)Page.LoadControl("~\\UserControl\\PostPreviewWithActions.ascx");
            c.Post = p;
            c1.Post = p;
            c2.Post = p;
            
            PlaceHolder1.Controls.Add(c);
            PlaceHolder1.Controls.Add(c1);
            PlaceHolder1.Controls.Add(c2);
        }
    }
}