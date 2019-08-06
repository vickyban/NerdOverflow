﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Forum

{
    public partial class admin1 : System.Web.UI.Page
    {
        private DataSet1 ds1 = new DataSet1();
        DataSet1TableAdapters.PostTableAdapter post = new DataSet1TableAdapters.PostTableAdapter();
        DataSet1TableAdapters.BanTableAdapter ban = new DataSet1TableAdapters.BanTableAdapter();

        private static int updateID = 0;
        private static int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection DbConnect = new SqlConnection();
            DbConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();
            SqlCommand comUser,comPost;

            string queryCountUser = "SELECT COUNT(*) AS totalUser FROM [User];";
            string queryCountPost = "SELECT COUNT(*) AS totalPost FROM [Post];";
            string queryApprovedPost = "SELECT COUNT(*) AS AprovedPost FROM Post WHERE(status = 'approved'); ";
            string queryBannedUser= "SELECT COUNT(*) AS UserBan FROM [Ban];";
            //Category
            string queryCabio = "SELECT COUNT(*) AS Categorybio FROM Post WHERE(category = 'school');  ";
            

            DbConnect.Open();

            //Total User
            comUser = new SqlCommand(queryCountUser, DbConnect);
            SqlDataReader reader = comUser.ExecuteReader();
            reader.Read();
            lblTotalUser1.Text = reader["totalUser"].ToString();
            reader.Close();

            //Total Post
            comPost = new SqlCommand(queryCountPost, DbConnect);
            SqlDataReader reader1 = comPost.ExecuteReader();
            reader1.Read();
            lblTotalPost.Text = reader1["totalPost"].ToString();
            decimal totalPost = Math.Round(Convert.ToDecimal(reader1["totalPost"]),0);
            reader1.Close();

            //Post status
            comPost = new SqlCommand(queryApprovedPost, DbConnect);
            SqlDataReader reader2 = comPost.ExecuteReader();
            reader2.Read();
            decimal resault = Math.Round((Convert.ToDecimal(reader2["AprovedPost"]) / totalPost)*100,0);
            lblPostStatus.Text = resault.ToString() + "%";
            progressbar.Style.Add("width", resault.ToString()+"%");
            reader2.Close();


            //Ban
            comPost = new SqlCommand(queryBannedUser, DbConnect);
            SqlDataReader reader3 = comPost.ExecuteReader();
            reader3.Read();
            lblBan.Text = reader3["UserBan"].ToString();
            reader3.Close();

            //Count total Bio post
            comPost = new SqlCommand(queryCabio, DbConnect);
            SqlDataReader reader4 = comPost.ExecuteReader();
            reader4.Read();
            string totalbio = reader4["Categorybio"].ToString();
            Categorybio.Value = totalbio;
            reader4.Close();


            DbConnect.Close();


            GridView1.DataBind();
            GridView2.DataBind();

            txtStartDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            string test = 10 + "%";
            bio.Style.Add("width", test);
        }

        protected void btnViewUser_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnViewPost_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string status = DataBinder.Eval(e.Row.Cells[4].Text, "approved").ToString();
         if (e.Row.RowType == DataControlRowType.DataRow) { 
                if (e.Row.Cells[5].Text.ToString() == "published")
                {
                    //chamge the forecolor and backcolor
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }else if (e.Row.Cells[5].Text.ToString() == "review")
                {
                    e.Row.ForeColor = System.Drawing.Color.YellowGreen;
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
            }
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "postDetails")
            {
                MultiView1.ActiveViewIndex = 3;
                
                GridViewRow row = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                updateID = Convert.ToInt32(row.Cells[0].Text);
                UserID = Convert.ToInt32(row.Cells[1].Text);

                SqlConnection DbConnect = new SqlConnection();
                DbConnect.ConnectionString =
                    System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();
                SqlCommand compostDetails;
                string queryPostDetails = "SELECT user_id, title, content, category, status FROM Post WHERE(post_id = "+ row.Cells[0].Text.ToString() 
                    + ");";

                DbConnect.Open();

                //Total User
                compostDetails = new SqlCommand(queryPostDetails, DbConnect);
                SqlDataReader reader = compostDetails.ExecuteReader();
                reader.Read();
                details.InnerText = reader["content"].ToString();
                lblTitle.Text = reader["title"].ToString();
                lblCategory.Text = reader["category"].ToString();
                lblUserID.Text = reader["user_id"].ToString();
                lblStatus.Text = reader["status"].ToString();
                if (lblStatus.Text == "ban")
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    btnBanUser1.Enabled = false;
                    btnApprove1.Enabled = true;
                }else
                {
                    if (lblStatus.Text == "approved") {
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        btnApprove1.Enabled = false;
                        btnBanUser1.Enabled = true;
                    }
                    else
                    {
                        lblStatus.ForeColor = System.Drawing.Color.YellowGreen;
                        btnApprove1.Enabled = true;
                        btnBanUser1.Enabled = true;
                    }
                }
                reader.Close();
               


            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnApprove1_Click(object sender, EventArgs e)
        {

            post.Fill(ds1.Post);
            DataRow[] dr = ds1.Post.Select("post_id=" + updateID);
       
            dr[0]["status"] = "approved";

            post.Update(ds1.Post);
            GridView1.DataBind();

            lblStatus.Text = dr[0]["status"].ToString();
            lblStatus.ForeColor = System.Drawing.Color.Green;
            btnApprove1.Enabled = false;
            btnBanUser1.Enabled = true;
        }

        protected void btnBanUser1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            post.Fill(ds1.Post);
            DataRow[] dr = ds1.Post.Select("post_id=" + updateID);
            lblUserIdBan.Text = dr[0]["user_id"].ToString();
            lblCurrentStatus.Text = dr[0]["status"].ToString();
        }

        protected void btnBanUser_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy")+ DateTime.Now.ToString(" HH:mm:ss");
            Calendar1.Visible = false;
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void btnselectEndDate_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = Calendar2.SelectedDate.ToString("MM/dd/yyyy") + DateTime.Now.ToString(" HH:mm:ss");
            Calendar2.Visible = false;
        }

        
        //View all post-->Ban user
        protected void btnConfirmBan_Click(object sender, EventArgs e)
        {
            
          
            if (txtEndDate.Text == "") {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the date!')", true);
            }
            else {
                ban.Fill(ds1.Ban);
                DataSet1.BanRow banRow = ds1.Ban.NewBanRow();
                banRow.user_id = Convert.ToInt32(lblUserIdBan.Text);
                banRow.status = "ban";
                banRow.start_date = Convert.ToDateTime(txtStartDate.Text);
                banRow.end_date = Convert.ToDateTime(txtEndDate.Text);
                banRow.created_at = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                ds1.Ban.Rows.Add(banRow);
                ban.Update(ds1.Ban);
                post.Fill(ds1.Post);
                DataRow[] dr = ds1.Post.Select("user_id=" + UserID);
                dr[0]["status"] = "ban";
                post.Update(ds1.Post);
                GridView1.DataBind();
                GridView2.DataBind();
                GridView3.DataBind();
                txtEndDate.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Success')", true);
            MultiView1.ActiveViewIndex = 5;
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Unbanned")
            {
                SqlConnection PostConnection = new SqlConnection();
                PostConnection.ConnectionString =
                    System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ConnectionString;

                SqlCommand cmd = PostConnection.CreateCommand();

                GridViewRow row = GridView3.Rows[Convert.ToInt32(e.CommandArgument)];
                UserID = Convert.ToInt32(row.Cells[1].Text);


                

                string updateCommand = "UPDATE Post SET status=@sta WHERE user_id = "+ UserID;
                SqlParameter userIDparam = new SqlParameter();
                userIDparam.ParameterName = "@sta";
                userIDparam.Value = "approved";

                cmd.CommandText = updateCommand;
                cmd.Parameters.Add(userIDparam);
                PostConnection.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();


                    string query = "Delete from Ban where user_id = " + UserID;
                    cmd.CommandText = query;
        

                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Unbanned Successfully!');", true);


                    cmd.Dispose();
                    PostConnection.Close();
                    GridView3.DataBind();



            }
        }
          
    }
}