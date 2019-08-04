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
            Header.CallBackMethod = this.Search;

            if(Request.QueryString["keyword"]!= null)
            {
                string keyword = Request.QueryString["keyword"];
                string filter = Request.QueryString["filter"];
                string sort = Request.QueryString["sort"];
                Posts = PostRepo.getPosts( keyword,filter, sort);
                Render();
            }
            else if (!IsPostBack)
            {
                Posts = PostRepo.getPosts(null, null, "DESC");
                Render();
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
        public void Search(string keyword, string filter, string sort)
        {
            Posts = PostRepo.getPosts(keyword, filter, sort);
            Render();
        }
    }
}