using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Login
{
    public partial class login1 : System.Web.UI.Page
    {
        public static string decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string str = System.Text.Encoding.UTF8.GetString(mybyte);
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection userInfoConnect = new SqlConnection();
            userInfoConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["registration"].ToString();
            userInfoConnect.Open();
            string checkuser = "select count(*) from registration where UserName='" + txtUserName.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser,userInfoConnect);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            userInfoConnect.Close();
            if (temp == 1)
            {
                userInfoConnect.Open();
                string checkPwdQuery = "select Password from registration where UserName='" + txtUserName.Text + "'";
                SqlCommand pwdcon = new SqlCommand(checkPwdQuery, userInfoConnect);
                string password = decode(pwdcon.ExecuteScalar().ToString().Replace(" ",""));

                string checkStatus = "select Status from registration where UserName='" + txtUserName.Text + "'";
                SqlCommand statuscon = new SqlCommand(checkStatus, userInfoConnect);
                string status = statuscon.ExecuteScalar().ToString().Replace(" ", "");

                if (password==txtPassword.Text)
                {
                    if (status == "ban")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Your account has been locked!');", true);
                    }
                    else
                    {
                        Session["New"] = txtUserName.Text;
                        string checkAdmin = "select Admin from registration where UserName='" + txtUserName.Text + "'";
                        SqlCommand admincon = new SqlCommand(checkAdmin, userInfoConnect);
                        string admin = admincon.ExecuteScalar().ToString().Replace(" ", "");
                        if (admin == "Yes")
                        {
                            Response.Redirect("http://localhost:60104/Admin/admin.aspx");
                        }
                        else
                        {
                            Response.Redirect("https://www.google.ca/");
                        }
                    }  
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Password is not right');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Use Name is not right');", true);
            }

        }
    }
}