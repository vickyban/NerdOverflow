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
                Content = HttpUtility.HtmlDecode("<p>Htish the nweme</p><p>Htish the nweme</p>"),
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