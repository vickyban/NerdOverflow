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

                }
            }
            else
            {

            }
        }
    }
}