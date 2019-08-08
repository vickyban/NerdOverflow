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
    /// <summary>
    ///  Author: Gia Vien Banh - 991501653
    ///  Business logic for User Profile page, allow user to update password and profile image
    /// </summary>
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
            // change class style to mark User profile is active 
            this.Master.ProfilePageBtn.CssClass = "user_right_navlink active";
            txtPassErr.Text = "";
        }

        /// <summary>
        /// Handle submission to upload profile image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handle submission to update user password. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Clear all text fields in the password updating form
        /// </summary>
        private void ClearPasswordForm()
        {
            txtOldPass.Text = "";
            txtNewPass.Text = "";
            txtConfirmedPass.Text = "";
        }

        /// <summary>
        /// invoke js message box on the Page
        /// </summary>
        /// <param name="message">Message to be displayed in the alert box</param>
        /// <param name="err">bool if this is an err or normal message</param>
        private void DisplayAlert(string message, bool err)
        {
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}