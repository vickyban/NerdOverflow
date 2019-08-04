using Forum.Models;
using Forum.Repositories;
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
        public List<Post> Posts { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Header.CallBackMethod = this.Render;
            if (!IsPostBack)
            {
                Posts = PostRepo.getPosts(null, null, "DESC");
                Render();
            }
            else
            {
                //string keyword = Request.QueryString["keyword"];
                //string filter = Request.QueryString["filter"];
                //string sort = Request.QueryString["sort"];
                //if(sort == null ) sort = "DESC";
                //Posts = PostRepo.getPosts(filter, keyword, sort);
            }
        }

        private void Render()
        {
            PlaceHolder1.Controls.Clear();
            foreach (var post in Posts)
            {
                PostPreviewWithActions control = (PostPreviewWithActions)Page.LoadControl("..\\UserControl\\PostPreviewWithActions.ascx");
                control.Post = post;
                PlaceHolder1.Controls.Add(control);
            }
        }
        public void Render(List<Post> posts)
        {
            Posts = posts;
            Render();
        }
    }
}