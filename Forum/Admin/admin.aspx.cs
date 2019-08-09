using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            SqlCommand comUser, comPost;

            string queryCountUser = "SELECT COUNT(*) AS totalUser FROM [User];";
            string queryCountPost = "SELECT COUNT(*) AS totalPost FROM [Post];";
            string queryApprovedPost = "SELECT COUNT(*) AS AprovedPost FROM Post WHERE(status = 'published'); ";
            string queryBannedUser = "SELECT COUNT(*) AS UserBan FROM [Ban];";
            //Category
            string queryCabioBio = "SELECT COUNT(*) AS Categorybio FROM Post WHERE(category = 'bio');  ";
            string queryCabioChem = "SELECT COUNT(*) AS Categorychem FROM Post WHERE(category = 'chem');  ";
            string queryCabioMaths = "SELECT COUNT(*) AS Categorymaths FROM Post WHERE(category = 'maths');  ";
            string queryCabioGeo = "SELECT COUNT(*) AS Categorygeo FROM Post WHERE(category = 'geo');  ";
            string queryCabioPhysic = "SELECT COUNT(*) AS Categoryphysic FROM Post WHERE(category = 'physic');  ";
            string queryCabioProgramming = "SELECT COUNT(*) AS CateOther FROM Post WHERE(category = 'other');  ";
            //Count posts from Jan to Dec
            string queryMonth1 = "SELECT COUNT(*) AS CountJan FROM Post WHERE DATENAME(month,created_at) = 'January'; ";
            string queryMonth2 = "SELECT COUNT(*) AS CountFeb FROM Post WHERE DATENAME(month,created_at) = 'February'; ";
            string queryMonth3 = "SELECT COUNT(*) AS CountMar FROM Post WHERE DATENAME(month,created_at) = 'March'; ";
            string queryMonth4 = "SELECT COUNT(*) AS CountApr FROM Post WHERE DATENAME(month,created_at) = 'April'; ";
            string queryMonth5 = "SELECT COUNT(*) AS CountMay FROM Post WHERE DATENAME(month,created_at) = 'May'; ";
            string queryMonth6 = "SELECT COUNT(*) AS CountJun FROM Post WHERE DATENAME(month,created_at) = 'June'; ";
            string queryMonth7 = "SELECT COUNT(*) AS CountJul FROM Post WHERE DATENAME(month,created_at) = 'July'; ";
            string queryMonth8 = "SELECT COUNT(*) AS CountAug FROM Post WHERE DATENAME(month,created_at) = 'August'; ";
            string queryMonth9 = "SELECT COUNT(*) AS CountSep FROM Post WHERE DATENAME(month,created_at) = 'September'; ";
            string queryMonth10 = "SELECT COUNT(*) AS CountOct FROM Post WHERE DATENAME(month,created_at) = 'October'; ";
            string queryMonth11 = "SELECT COUNT(*) AS CountNov FROM Post WHERE DATENAME(month,created_at) = 'November'; ";
            string queryMonth12 = "SELECT COUNT(*) AS CountDec FROM Post WHERE DATENAME(month,created_at) = 'December'; ";



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
            decimal totalPost = Math.Round(Convert.ToDecimal(reader1["totalPost"]), 0);
            reader1.Close();

            //Post status
            comPost = new SqlCommand(queryApprovedPost, DbConnect);
            SqlDataReader reader2 = comPost.ExecuteReader();
            reader2.Read();
            decimal resault = Math.Round((Convert.ToDecimal(reader2["AprovedPost"]) / totalPost) * 100, 0);
            lblPostStatus.Text = resault.ToString() + "%";
            progressbar.Style.Add("width", resault.ToString() + "%");
            reader2.Close();


            //Ban
            comPost = new SqlCommand(queryBannedUser, DbConnect);
            SqlDataReader reader3 = comPost.ExecuteReader();
            reader3.Read();
            lblBan.Text = reader3["UserBan"].ToString();
            reader3.Close();

            //Count total Bio post
            comPost = new SqlCommand(queryCabioBio, DbConnect);
            SqlDataReader reader4 = comPost.ExecuteReader();
            reader4.Read();
            string totalbio = reader4["Categorybio"].ToString();
            reader4.Close();
            //Count total Chem post
            comPost = new SqlCommand(queryCabioChem, DbConnect);
            SqlDataReader reader5 = comPost.ExecuteReader();
            reader5.Read();
            string totalChem = reader5["Categorychem"].ToString();
            reader5.Close();
            //Count total Maths post
            comPost = new SqlCommand(queryCabioMaths, DbConnect);
            SqlDataReader reader6 = comPost.ExecuteReader();
            reader6.Read();
            string totalMaths = reader6["Categorymaths"].ToString();
            reader6.Close();
            //Count total Geo post
            comPost = new SqlCommand(queryCabioGeo, DbConnect);
            SqlDataReader reader7 = comPost.ExecuteReader();
            reader7.Read();
            string totalGeo = reader7["Categorygeo"].ToString();
            reader7.Close();
            //Count total Physic post
            comPost = new SqlCommand(queryCabioPhysic, DbConnect);
            SqlDataReader reader8 = comPost.ExecuteReader();
            reader8.Read();
            string totalPhysic = reader8["Categoryphysic"].ToString();
            reader8.Close();
            //Count total other post
            comPost = new SqlCommand(queryCabioProgramming, DbConnect);
            SqlDataReader reader9 = comPost.ExecuteReader();
            reader9.Read();
            string totalOther = reader9["CateOther"].ToString();
            reader9.Close();



            //Count total post in Jan
            comPost = new SqlCommand(queryMonth1, DbConnect);
            SqlDataReader reader10 = comPost.ExecuteReader();
            reader10.Read();
            string totalJan = reader10["CountJan"].ToString();
            reader10.Close();

            //Count total post in Feb
            comPost = new SqlCommand(queryMonth2, DbConnect);
            SqlDataReader reader11 = comPost.ExecuteReader();
            reader11.Read();
            string totalFeb = reader11["CountFeb"].ToString();
            reader11.Close();

            //Count total post in Mar
            comPost = new SqlCommand(queryMonth3, DbConnect);
            SqlDataReader reader12 = comPost.ExecuteReader();
            reader12.Read();
            string totalMar = reader12["CountMar"].ToString();
            reader12.Close();

            //Count total post in April
            comPost = new SqlCommand(queryMonth4, DbConnect);
            SqlDataReader reader13 = comPost.ExecuteReader();
            reader13.Read();
            string totalApr = reader13["CountApr"].ToString();
            reader13.Close();

            //Count total post in May
            comPost = new SqlCommand(queryMonth5, DbConnect);
            SqlDataReader reader14 = comPost.ExecuteReader();
            reader14.Read();
            string totalMay = reader14["CountMay"].ToString();
            reader14.Close();

            //Count total post in Jun
            comPost = new SqlCommand(queryMonth6, DbConnect);
            SqlDataReader reader15 = comPost.ExecuteReader();
            reader15.Read();
            string totalJun = reader15["CountJun"].ToString();
            reader15.Close();

            //Count total post in Jul
            comPost = new SqlCommand(queryMonth7, DbConnect);
            SqlDataReader reader16 = comPost.ExecuteReader();
            reader16.Read();
            string totalJul = reader16["CountJul"].ToString();
            reader16.Close();

            //Count total post in Aug
            comPost = new SqlCommand(queryMonth8, DbConnect);
            SqlDataReader reader17 = comPost.ExecuteReader();
            reader17.Read();
            string totalAug = reader17["CountAug"].ToString();
            reader17.Close();

            //Count total post in Sep
            comPost = new SqlCommand(queryMonth9, DbConnect);
            SqlDataReader reader18 = comPost.ExecuteReader();
            reader18.Read();
            string totalSep = reader18["CountSep"].ToString();
            reader18.Close();

            //Count total post in Oct
            comPost = new SqlCommand(queryMonth10, DbConnect);
            SqlDataReader reader19 = comPost.ExecuteReader();
            reader19.Read();
            string totalOct = reader19["CountOct"].ToString();
            reader19.Close();

            //Count total post in Nov
            comPost = new SqlCommand(queryMonth11, DbConnect);
            SqlDataReader reader20 = comPost.ExecuteReader();
            reader20.Read();
            string totalNov = reader20["CountNov"].ToString();
            reader20.Close();

            //Count total post in Dec
            comPost = new SqlCommand(queryMonth12, DbConnect);
            SqlDataReader reader21 = comPost.ExecuteReader();
            reader21.Read();
            string totalDec = reader21["CountDec"].ToString();
            reader21.Close();

            DbConnect.Close();


            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();

            txtStartDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            //Hidden field data
            hidBio.Value = totalbio;
            hidChem.Value = totalChem;
            hidGeo.Value = totalGeo;
            hidMath.Value = totalMaths;
            hidPhysic.Value = totalPhysic;
            hidOther.Value = totalOther;

            hidJan.Value = totalJan;
            hidFeb.Value = totalFeb;
            hidMar.Value = totalMar;
            hidApr.Value = totalApr;
            hidMay.Value = totalMar;
            hidJun.Value = totalJun;
            hidJul.Value = totalJul;
            hidAug.Value = totalAug;
            hidSep.Value = totalSep;
            hidOct.Value = totalOct;
            hidNov.Value = totalNov;
            hidDec.Value = totalDec;

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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.ToString() == "published")
                {
                    //chamge the forecolor and backcolor
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
                else if (e.Row.Cells[5].Text.ToString() == "review")
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
                string queryPostDetails = "SELECT user_id, title, content, category, status FROM Post WHERE(post_id = " + row.Cells[0].Text.ToString()
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
                }
                else
                {
                    if (lblStatus.Text == "published")
                    {
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

            dr[0]["status"] = "published";

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
            txtStartDate.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy") + DateTime.Now.ToString(" HH:mm:ss");
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


            if (txtEndDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the date!')", true);
            }
            else if (Convert.ToDateTime(txtEndDate.Text) < DateTime.Now)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the date after current datetime!')", true);
            }
            else
            {
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
                for (int i = 0; i < dr.Length; i++)
                {
                    dr[i]["status"] = "ban";
                    post.Update(ds1.Post);
                }
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
            GridViewRow row = GridView3.Rows[Convert.ToInt32(e.CommandArgument)];
            if (e.CommandName == "Unbanned")
            {
                SqlConnection PostConnection = new SqlConnection();
                PostConnection.ConnectionString =
                    System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ConnectionString;

                SqlCommand cmd = PostConnection.CreateCommand();

                UserID = Convert.ToInt32(row.Cells[1].Text);




                string updateCommand = "UPDATE Post SET status=@sta WHERE user_id = " + UserID;
                SqlParameter userIDparam = new SqlParameter();
                userIDparam.ParameterName = "@sta";
                userIDparam.Value = "published";

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

        /// <summary>
        /// Unselectable if is the prvious datetime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date <= DateTime.Now)
            {

                e.Cell.BackColor = System.Drawing.Color.Gray;

                e.Day.IsSelectable = false;

            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date <= DateTime.Now)
            {

                e.Cell.BackColor = System.Drawing.Color.Gray;

                e.Day.IsSelectable = false;

            }
        }


    }

}