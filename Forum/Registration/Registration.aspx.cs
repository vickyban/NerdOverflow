using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Registration
{
    public partial class Registration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Encode to Base64 format
        /// </summary>
        /// <param name="str"></param>
        /// <returns>msg</returns>
        public string Encrpted(string str)
        {
            string msg = "";
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        /// <summary>
        /// Insert user information to database(Name, Email, Encoded Password, isAdmin)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection userInfoConnect = new SqlConnection();
            userInfoConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();
            SqlCommand cmd = userInfoConnect.CreateCommand();
            userInfoConnect.Open();
            try
            {
                string checkUser = "select * from [User] where username='" + txtUserName.Text + "'";
                SqlCommand con = new SqlCommand(checkUser, userInfoConnect);
                var reader = con.ExecuteReader();
                
                //Check user name duplication
                if (reader.HasRows)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('User name is already in used. Please try another one :)');", true);
                }
                else
                {
                    //Insert query user Info to database
                    string query = "Insert into [User](username,password,email,isAdmin)values(@UserName,@Password,@Email,@Admin)";
                    SqlParameter userparam = new SqlParameter();
                    userparam.ParameterName = "@UserName";
                    userparam.Value = txtUserName.Text;

                    SqlParameter emailparam = new SqlParameter();
                    emailparam.ParameterName = "@Email";
                    emailparam.Value = txtEmail.Text;

                    SqlParameter passwordparam = new SqlParameter();

                    if (txtPassword.Text.Equals(txtConfirm.Text))
                    {
                        passwordparam.ParameterName = "@Password";
                        passwordparam.Value = Encrpted(txtPassword.Text);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('The password is not matched');", true);
                    }

                    SqlParameter adminparam = new SqlParameter();
                    adminparam.ParameterName = "@Admin";
                    //If the user is Admin.
                    if (ddlAdmin.SelectedValue == "YES")
                    {
                        //A text box shown, need to enter Admin Code
                        txtAdmin.Visible = true;
                        if (txtAdmin.Text.Equals("Zoe123") || txtAdmin.Text.Equals("Jason456") ||
                            txtAdmin.Text.Equals("Vicky789") || txtAdmin.Text.Equals("John567"))
                        {
                            adminparam.Value = 1;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Invalid Admin ID');", true);
                        }

                    }
                    else if (ddlAdmin.SelectedValue == "NO")
                    {
                        txtAdmin.Visible = false;
                        adminparam.Value = 0;
                    }

                    reader.Close();
                    cmd.CommandText = query;
                    cmd.Parameters.Add(userparam);
                    cmd.Parameters.Add(passwordparam);
                    cmd.Parameters.Add(emailparam);
                    cmd.Parameters.Add(adminparam);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("http://localhost:60104/Login/login.aspx");
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