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
        
        public string Encrpted(string str)
        {
            string msg = "";
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection userInfoConnect = new SqlConnection();
            userInfoConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["registration"].ToString();
            SqlCommand cmd = userInfoConnect.CreateCommand();
            try
            {
                string query = "Insert into registration(UserName,Email,Password,Admin) values (@UserName,@Email,@Password,@Admin)";

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
                if (ddlAdmin.SelectedValue=="YES")
                {
                    txtAdmin.Visible = true;
                    if (txtAdmin.Text.Equals("Zoe123")|| txtAdmin.Text.Equals("Jason456") ||
                        txtAdmin.Text.Equals("Vicky789") || txtAdmin.Text.Equals("John567"))
                    {
                        adminparam.Value = "Yes";
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myjs", "alert('Invalid Admin ID');", true);
                    }
                    
                }
                else if(ddlAdmin.SelectedValue == "NO")
                {
                    txtAdmin.Visible = false;
                    adminparam.Value = "No";
                }

                cmd.CommandText = query;

                cmd.Parameters.Add(userparam);
                cmd.Parameters.Add(emailparam);
                cmd.Parameters.Add(passwordparam);
                cmd.Parameters.Add(adminparam);

                userInfoConnect.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("http://localhost:60104/Login/login.aspx");
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