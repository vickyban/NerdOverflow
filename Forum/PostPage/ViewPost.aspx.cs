using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.PostPage
{
    public partial class ViewPost : System.Web.UI.Page
    {
        private Post userPost = new Post();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // Convert.ToInt32(Session["userID"]; For Session
                userPost = Repositories.PostRepo.viewPost(2, 5);
                showPost();
            }

        }

        void showPost()
        {
            // ------------------------ THIS IS FOR TIME -----------------------------------
            DateTime postedDate = userPost.CreatedAt;
            DateTime dateNow = DateTime.Now;
            int days = Convert.ToInt32((dateNow - postedDate).TotalDays);
            int hours = Convert.ToInt32((dateNow - postedDate).TotalHours);
            int minutes = Convert.ToInt32((dateNow - postedDate).TotalMinutes);

            if (days == 0)
            {
                if (hours > 1)
                {
                    lblDate.Text = "Posted by " + "USERNAME " + hours + " hours ago";
                }
                else if (hours == 1)
                {
                    lblDate.Text = "Posted by " + "USERNAME " + hours + " hours ago";
                }
                else
                {
                    if (minutes > 1)
                    {
                        lblDate.Text = "Posted by " + "USERNAME " + minutes + " minutes ago";
                    }
                    else if (minutes == 1)
                    {
                        lblDate.Text = "Posted by " + "USERNAME " + minutes + " minute ago";
                    }
                }
            }
            else
            {
                if (days > 1)
                {
                    lblDate.Text = "Posted by " + "USERNAME " + days + " days ago";
                }
                else if (days == 1)
                {
                    lblDate.Text = "Posted by " + "USERNAME " + days + " day ago";
                }

            }

            // ----------------------- CONTENT -------------------------------------

            // IMAGE
            if (userPost.Image != null)
            {
                postImage.ImageUrl = "data:Image/png;base64," + userPost.Image;
                postImage.Visible = true;
            }

            // CONTENT TEXT
            lblContentMessage.Text = userPost.Content.ToString();
        }
    }
}