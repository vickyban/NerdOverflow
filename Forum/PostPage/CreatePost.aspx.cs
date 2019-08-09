using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace Forum.PostPage
{
    public partial class CreatePost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //this.Session.Add("userID", 3);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                    query = "Insert into Post values (@UserID, @Title, @Category, @Content, @Image, @Status,@Date,@Date2);";

                    SqlParameter image = new SqlParameter();
                    image.ParameterName = "@Image";

                    HttpPostedFile postedFile = FileUpload1.PostedFile;
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".jpeg")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        image.Value = bytes;
                        cmd.Parameters.Add(image);
                    }
                    else
                    {


                    }

                }
                else
                {
                    query = "Insert into Post values (@UserID, @Title, @Category, @Content, NULL, @Status,@Date,@Date2);";
                }

                SqlParameter userID = new SqlParameter();
                userID.ParameterName = "@UserID";
                userID.Value = Convert.ToInt32(Session["userID"]);

                SqlParameter title = new SqlParameter();
                title.ParameterName = "@Title";
                title.Value = txtTitle.Text;

                SqlParameter content = new SqlParameter();
                content.ParameterName = "@Content";
                content.Value = txtContent.Text;

                SqlParameter category = new SqlParameter();
                category.ParameterName = "@Category";
                category.Value = ddCategory.SelectedValue.ToString();

                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Value = "published";
              

                SqlParameter dateCreated = new SqlParameter();
                dateCreated.ParameterName = "@Date";
                dateCreated.Value = DateTime.Now;

                SqlParameter dateUpdated = new SqlParameter();
                dateUpdated.ParameterName = "@Date2";
                dateUpdated.Value = DateTime.Now;


                // step 5: Set the commandtext to the query you made
                cmd.CommandText = query;

                // step 6: Add the parameters to the SqlCommand
                cmd.Parameters.Add(userID);
                cmd.Parameters.Add(title);
                cmd.Parameters.Add(content);
                cmd.Parameters.Add(category);
                cmd.Parameters.Add(status);
                cmd.Parameters.Add(dateCreated);
                cmd.Parameters.Add(dateUpdated);

                // Open the sql Connection
                dbConnect.Open();

                // execute the query code
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "postCreated()", true);
                    ddCategory.SelectedIndex = 0;
                    txtTitle.Text = "";
                    txtContent.Text = "";
                }
            }
            catch (SqlException ex)
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();

                    if (ext != "jpg" || ext != "bmp" || ext != "png" || ext != "gif" || ext != "jpeg")
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