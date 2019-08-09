using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Author: Haoyue Wang
/// </summary>
namespace Forum.Login
{
    public partial class login1 : System.Web.UI.Page
    {
        /// <summary>
        /// Decode from Base64 format
        /// </summary>
        /// <param name="text"></param>
        /// <returns>str</returns>
        public static string decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string str = System.Text.Encoding.UTF8.GetString(mybyte);
            return str;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// User Login(Validate user's password, status, isAdmin)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection userInfoConnect = new SqlConnection();
            userInfoConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();
            userInfoConnect.Open();
            string checkuser = "select count(*) from [User] where username='" + txtUserName.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, userInfoConnect);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            try
            {
                //Check if the user is register or not
                if (temp == 1)
                {
                    //Get values from [User] database
                    string checkPwdQuery = "select user_id,password, isAdmin from [User] where username='" + txtUserName.Text + "'";
                    SqlCommand pwdcon = new SqlCommand(checkPwdQuery, userInfoConnect);
                    var reader = pwdcon.ExecuteReader();
                    string password = "";
                    User user = new User();
                    while (reader.Read())
                    {
                        password = decode(reader["password"].ToString());
                        user.UserId = Convert.ToInt32(reader["user_id"].ToString());
                        user.IsAdmin = reader.GetBoolean(2);
                    }
                    reader.Close();

                    //Get values from [Ban] database
                    string checkStatus = "select status, start_date, end_date from [Ban] where user_id='" + user.UserId + "'";
                    SqlCommand statuscon = new SqlCommand(checkStatus, userInfoConnect);
                    string status = "";
                    reader = statuscon.ExecuteReader();
                    DateTime startDate ;
                    DateTime endDate ;

                    if (reader.Read())
                    {
                        status = reader.GetString(0);
                        startDate = reader.GetDateTime(1);
                        endDate = reader.GetDateTime(2);
                        reader.Close();
                        TimeSpan interval = startDate - endDate;
                        int x = (int)interval.TotalMinutes;

                        // check the user if still ban or not 
                        if (status == "ban")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Your account has been blockes! Left time: " + x + " " + " minutes" + "');", true);
                            return;
                        } 
                    }

                    if (password == txtPassword.Text)
                    {
                        //Store user information using Session
                        Session["UserName"] = txtUserName.Text;
                        Session["Password"] = password;
                        Session["UserId"] = user.UserId;
                        Session["isAdmin"] = user.IsAdmin;

                        //Check the user is Admin or not
                        if (user.IsAdmin)
                        {
                            Response.Redirect("http://localhost:60104/Admin/admin.aspx");
                        }
                        else
                        {
                            Response.Redirect("http://localhost:60104/StaticPages/HomePage.aspx");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Password is wrong!!!');", true);
                    }
                }    
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Please register first :)');", true);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs1", "alert('" + msg + "');", true);
            }
            finally
            {
                cmd.Dispose();
                userInfoConnect.Close();
            }
        }
    }
}