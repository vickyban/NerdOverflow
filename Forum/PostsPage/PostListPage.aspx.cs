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
    /// <summary>
    /// Author: Gia Vien Banh
    /// page to display list of posts 
    /// </summary>
    public partial class PostListPage : System.Web.UI.Page
    {
        public List<Post> Posts { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Request.QueryString["keyword"]!= null)
            {
                string keyword = Request.QueryString["keyword"];
                string rawfilters = Request.QueryString["filters"];
                string filters = "";
                if (rawfilters != "")
                filters = string.Join(",",rawfilters.Split(',').Select(v => $"'{v}'"));
                string sort = Request.QueryString["sort"];
                Posts = PostRepo.getPosts( keyword,filters, sort);
                Render();
            }
            else if (!IsPostBack)
            {
                Posts = PostRepo.getPosts("", "", "DESC");
                Render();
            }

        }
        /// <summary>
        /// Render postPreview user controller for each post to display in the placeholder
        /// </summary>
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
    }
}