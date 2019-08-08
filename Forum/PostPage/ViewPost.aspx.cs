using Forum.Models;
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
        Post userPost = new Post();
        int postID;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Convert.ToInt32(Session["userID"]; For Session
            // viewPost takes a parameter is POSTID
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int postId);
            postID = postId;

      
            userPost = Repositories.PostRepo.GetPost(postId);
            ShowPost();

            // POSTID
            List<Comment> comments = CommentRepo.GetComments(postId);
            CommentSection.Comments = comments;

            btnPost1.Text = "August 8 2019      \n" +  + " Poyo                                                  " +  "This exam is crazy!";

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
                    lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + hours + " hours ago";
                }
                else if (hours == 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + hours + " hour ago";
                }
                else
                {
                    if (minutes > 1)
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + minutes + " minutes ago";
                    }
                    else if (minutes == 1)
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + minutes + " minute ago";
                    }
                    else
                    {
                        lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + " just now";
                    }
                }
            }
            else
            {
                if (days > 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + days + " days ago";
                }
                else if (days == 1)
                {
                    lblDate.Text = userPost.Category + " • Posted by " + "USERNAME " + days + " day ago";
                }

            }

            // ----------------------- CONTENT -------------------------------------

            // IMAGE
            if (userPost.Image != null)
            {
                postImage.ImageUrl = "data:Image/png;base64," + userPost.Image;
                postImage.Visible = true;
            } else
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
            // CHANGE THE PARAMETERS
            SubmitComment(3, postID);
            txtComment.Text = "";
        }


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
            // CHANGE THE USERID AND POSTID
            ReportPost(2, postID);
            // Update post status. CHANGE POSTID
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
                                "SET status = 'review' , updated_at = '"  + DateTime.Now +"'" +
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
    }
}