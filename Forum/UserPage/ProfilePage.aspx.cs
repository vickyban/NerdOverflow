using Forum.Helpers;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        public int UserId
        {
            get
            {
                if (int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId))
                    return userId;
                else { return 0; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.ProfilePageBtn.CssClass = "user_right_navlink active";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // check if file is uploaded 
            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if(extension == ".jpg" || extension == ".png")
                {
                    int length = FileUpload1.PostedFile.ContentLength;
                    byte[] img = new byte[length];
                    FileUpload1.PostedFile.InputStream.Read(img, 0, length);
                    UserRepo.SaveImage(UserId, img);
                    Response.Redirect(Page.Request.Url.ToString());
                }
                else
                {
                    DisplayAlert("Failed to upload image. Must be in correct format!",true);
                }
            }
        }

        protected void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string password = PasswordHelper.Encrypted(txtOldPass.Text);
                string actualPassword = UserRepo.GetUserPassword(UserId);
                if (password == actualPassword)
                {
                    string newPassword = PasswordHelper.Encrypted(txtNewPass.Text);
                    UserRepo.UpdatePassword(UserId, newPassword);
                    DisplayAlert("Successfully updated password", false);
                }
                else
                {
                    txtPassErr.Text = "Invalid password. Please enter correct password";
                }
                ClearPasswordForm();
            }
        }

        private void ClearPasswordForm()
        {
            txtOldPass.Text = "";
            txtNewPass.Text = "";
            txtConfirmedPass.Text = "";
        }

        private void DisplayAlert(string message, bool err)
        {
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}