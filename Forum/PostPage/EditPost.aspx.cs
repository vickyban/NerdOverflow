using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forum.Models;
using Forum.Repositories;

namespace Forum.PostPage
{
    public partial class EditPost : System.Web.UI.Page
    {
        Post post = new Post();

        protected void Page_Load(object sender, EventArgs e)
        {
            post = Repositories.PostRepo.getPost(9);

            // GET ALL VALUES OF THE POST. CHANGE THE POSTID
            if (!Page.IsPostBack) { 
            txtTitle.Text = post.Title;
            ddCategory.SelectedValue = post.Category;
            txtContent.Text = post.Content;
            } else
            {
              //  Response.Redirect(Request.RawUrl);
            }
        }

 

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == post.Title && ddCategory.SelectedValue == post.Category
               && txtContent.Text == post.Content && chkDelete.Checked == false && !FileUpload1.HasFile)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "noUpdate()", true);
            }
            else if (txtTitle.Text != post.Title || ddCategory.SelectedValue != post.Category
               || txtContent.Text != post.Content || chkDelete.Checked != false || FileUpload1.HasFile)
            {
                if (FileUpload1.HasFile && chkDelete.Checked == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "errorImage()", true);
                } else
                {
                    updatePost();
                    chkDelete.Checked = false;
                }
                            
            }
        }

        // UPDATE THE POST
        void updatePost()
        {
            SqlConnection dbConnect = new SqlConnection();

            SqlCommand cmd = dbConnect.CreateCommand();

            dbConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();

            try
            {
                string query;

                // IF the post has an image

                if (FileUpload1.HasFile)
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , post_image = @Image , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + 9;

                    SqlParameter image = new SqlParameter();
                    image.ParameterName = "@Image";

                    HttpPostedFile postedFile = FileUpload1.PostedFile;
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        image.Value = bytes;
                        cmd.Parameters.Add(image);
                    }
                }
                else if(chkDelete.Checked == true)
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , post_image = NULL , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + 9;
                } else
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + 9;
                }

                SqlParameter title = new SqlParameter();
                title.ParameterName = "@Title";
                title.Value = txtTitle.Text;

                SqlParameter content = new SqlParameter();
                content.ParameterName = "@Content";
                content.Value = txtContent.Text;

                SqlParameter category = new SqlParameter();
                category.ParameterName = "@Category";
                category.Value = ddCategory.SelectedValue.ToString();

                // step 5: Set the commandtext to the query you made
                cmd.CommandText = query;

                // step 6: Add the parameters to the SqlCommand
                cmd.Parameters.Add(title);
                cmd.Parameters.Add(content);
                cmd.Parameters.Add(category);


                // Open the sql Connection
                dbConnect.Open();

                // execute the query code
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "postUpdated()", true);
                }
            }
            catch (SqlException ex)
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();

                    if (ext != "jpg" || ext != "bmp" || ext != "png" || ext != "gif")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", "error()", true);
                    }

                }
                else
                {
                    
                }
            }
            finally
            {
                cmd.Dispose();
                dbConnect.Close();
            }
        }
    }
}