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

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Page.IsPostBack == false)
            {
                // Convert.ToInt32(Session["userID"]; For Session
                // viewPost takes 2 parameter which are USERID and POSTID
                userPost = Repositories.PostRepo.viewPost(3, 9);
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
                    } else
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
            }

            // CONTENT TEXT
            lblContentMessage.Text = userPost.Content.ToString();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            
        }

        

        protected void btnComment_Click(object sender, EventArgs e)
        {
            submitComment(3, 12, txtComment.ToString());
            txtComment.Text = "";
        }

        void submitComment(int userID, int postID, string content)
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
            }
        }
    }
}