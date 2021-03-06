﻿using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Forum.PostPage
{
    public partial class ViewPost : System.Web.UI.Page
    {
        // Instances of a Post and User Class, and postID and userID.
        Post userPost = new Post();
        private List<Post> posts;
        User user = new User();
        int postID;

        int userID;
        protected void Page_Load(object sender, EventArgs e)
        {


            // Assigning the ID of the post to postId variable.
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int postId);
            postID = postId;

            // Setting the comment section disabled if the user is not logged in.
            if (Session["UserId"] != null)
            {
                userID = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                txtComment.Enabled = false;
            }

            //Gets the  specific post the user have clicked
            userPost = Repositories.PostRepo.GetPost(postId);
            if(userPost.PostId == 0)
            {
                Response.Redirect("/NotFoundPage.aspx");
            }
            user = Repositories.UserRepo.GetUser(userPost.UserId);
            lbTitle.Text = userPost.Title;
            ShowPost();

            // POSTID
            List<Comment> comments = CommentRepo.GetComments(postId);
            CommentSection.Comments = comments;

            // Fetching recent posts
            posts = Repositories.PostRepo.GetPosts();
            var btns = new List<Button>
            {
                btnPost1, btnPost2, btnPost3, btnPost4, btnPost5
            };
            for (int i = 0; i < posts.Count && i < 5; i++) {
                btns[i].Text = posts[i].Category + ": " + posts[i].Title;
            //btnPost1.Text = posts[0].Category + ": " + posts[0].Title;
            //btnPost2.Text = posts[1].Category + ": " + posts[1].Title;
            //btnPost3.Text = posts[2].Category + ": " + posts[2].Title;
            //btnPost4.Text = posts[3].Category + ": " + posts[3].Title;
            //btnPost5.Text = posts[4].Category + ": " + posts[4].Title;
            }                   


        }


        void ShowPost()
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
                    lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + hours + " hours ago";
                }
                else if (hours == 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + hours + " hour ago";
                }
                else
                {
                    if (minutes > 1)
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + minutes + " minutes ago";
                    }
                    else if (minutes == 1)
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + minutes + " minute ago";
                    }
                    else
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + " just now";
                    }
                }
            }
            else
            {
                if (days > 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + " days ago";
                }
                else if (days == 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + user.Username + " " + " day ago";
                }

            }

            // ----------------------- CONTENT -------------------------------------

            // IMAGE
            if (userPost.Image != null)
            {
                postImage.ImageUrl = "data:Image/png;base64," + userPost.Image;
                postImage.Visible = true;
            }
            else
            {
                postImage.Visible = false;
                postImage.CssClass = "noImage";
            }

            // CONTENT TEXT
            lblContentMessage.Text = userPost.Content.ToString();


            // Comment - CHANGE THE POSTID
            int commentCount = CommentRepo.commentCount(postID);
            if (commentCount > 1)
            {
                lblComment.Text = commentCount.ToString() + " Comments";
            }
            else
            {
                lblComment.Text = commentCount.ToString();
            }

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {

        }

        // COMMENT TO DATABASE
        protected void btnComment_Click(object sender, EventArgs e)
        {
            SubmitComment(userID, postID);
            txtComment.Text = "";   
        }

        //Submits the comment using the userID and PostID to know who made the comment and to which post.
        void SubmitComment(int userID, int postID)
        {
            SqlConnection dbConnect = new SqlConnection();

            SqlCommand cmd = dbConnect.CreateCommand();

            dbConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();

            try
            {
                string query = "Insert into Comment values (@UserID, @PostID, NULL , @Comment, @Date1, @Date2);";

                SqlParameter user = new SqlParameter();
                user.ParameterName = "@UserID";
                user.Value = userID;

                SqlParameter post = new SqlParameter();
                post.ParameterName = "@PostID";
                post.Value = postID;

                SqlParameter commentContent = new SqlParameter();
                commentContent.ParameterName = "@Comment";
                commentContent.Value = txtComment.Text;

                SqlParameter dateCreated = new SqlParameter();
                dateCreated.ParameterName = "@Date1";
                dateCreated.Value = DateTime.Now;

                SqlParameter dateupdated = new SqlParameter();
                dateupdated.ParameterName = "@Date2";
                dateupdated.Value = DateTime.Now;

                cmd.CommandText = query;

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(post);
                cmd.Parameters.Add(commentContent);
                cmd.Parameters.Add(dateCreated);
                cmd.Parameters.Add(dateupdated);

                // Open the sql Connection
                dbConnect.Open();

                // execute the query code
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cmd.Dispose();
                dbConnect.Close();
                Response.Redirect(Request.RawUrl);
            }
        }

        // REPORTED POST TO DATABASE
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // If the user is not logged in and they try to flag a post, this will not be added to the databaes and will give them an error alert. 
            if (Session["UserId"] != null)
            {
                ReportPost(userID, postID);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "errorReport()", true);
            }
          
        }

        void ReportPost(int userID, int postID)
        {
            SqlConnection dbConnect = new SqlConnection();

            SqlCommand cmd = dbConnect.CreateCommand();

            dbConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();

            try
            {
                string query = "Insert into Reported values (@UserID, @PostID, @Reason, @Date1);";

                // CHANGE POST_ID
                string query2 = "UPDATE Post " +
                                "SET status = 'review' , updated_at = '" + DateTime.Now + "'" +
                                "WHERE post_id = " + postID;

                SqlParameter user = new SqlParameter();
                user.ParameterName = "@UserID";
                user.Value = userID;

                SqlParameter post = new SqlParameter();
                post.ParameterName = "@PostID";
                post.Value = postID;

                SqlParameter reason = new SqlParameter();
                reason.ParameterName = "@Reason";
                reason.Value = txtReason.Text.ToString();

                SqlParameter created = new SqlParameter();
                created.ParameterName = "@Date1";
                created.Value = DateTime.Now;

                cmd.CommandText = query;

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(post);
                cmd.Parameters.Add(reason);
                cmd.Parameters.Add(created);

                dbConnect.Open();

                // execute the query code
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    cmd.CommandText = query2;
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "successPost()", true);
                }

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cmd.Dispose();
                dbConnect.Close();
            }
        }

        // Buttons used for advertisements
        protected void btnPost1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{posts[0].PostId}/");
        }

        protected void btnPost2_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{posts[1].PostId}/");
        }

        protected void btnPost3_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{posts[2].PostId}/");
        }

        protected void btnPost4_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{posts[3].PostId}/");
        }

        protected void btnPost5_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{posts[4].PostId}/");
        }
    }
}