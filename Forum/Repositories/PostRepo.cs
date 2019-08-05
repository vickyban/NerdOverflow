using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.Repositories
{
    public class PostRepo : BaseRepo
    {
        public static List<Post> getPosts(int userId, List<string> filters, string orderBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "SELECT DISTINCT " +
                "p.post_id, p.title, p.category, p.created_at, p.status, " +
                "u.user_id, u.username, " +
                "count(c.comment_id) OVER (PARTITION BY p.post_id) AS total_comment " +
                "FROM [Post] p INNER JOIN [User] u " +
                "ON p.user_id = u.user_id " +
                "LEFT OUTER JOIN [Comment] c " +
                "ON p.post_id = c.post_id " +
                "WHERE p.user_id = @Userid " +
                "AND p.status IN (" + string.Join(", ", filters) + ") " +
                "ORDER BY p.created_at " + orderBy;
            SqlParameter param = new SqlParameter("Userid", userId);
            cmd.CommandText = query;
            cmd.Parameters.Add(param);
            List<Post> posts = new List<Post>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    reader.Read();
                    Post post = new Post
                    {
                        PostId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Category = reader.GetString(2),
                        CreatedAt = reader.GetDateTime(3),
                        Status = reader.GetString(4),
                        TotalComments = reader.GetInt32(7),
                        User = new User
                        {
                            UserId = reader.GetInt32(5),
                            Username = reader.GetString(6)
                        }
                    };
                    posts.Add(post);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return posts;
        }
    
        public static void DeletePost(int postId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            string[] queries = new string[] {
                "DELETE FROM [Bookmark] WHERE post_id = @ID",
                "DELETE FROM [Comment] WHERE post_id = @ID",
                "DELETE FROM [Post] WHERE post_id = @ID; "
            };
            SqlCommand cmd = con.CreateCommand();
            cmd.Parameters.Add(new SqlParameter("ID", postId));
            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                {
                    cmd.Transaction = transaction;
                    foreach(var query in queries)
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }catch(Exception ex) {
                Console.WriteLine("ROLL BACK DELETE POST");
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                con.Close();
            }
        }

        public static Post viewPost(int userID, int postID)
        {
            SqlConnection dbConnect = new SqlConnection(connectionString);

            SqlCommand cmd = dbConnect.CreateCommand();

            Post userPost = new Post();

            try
            {
                string query = "Select * From Post Where post_id =" + 8;

                dbConnect.Open();

                // These two are important when using SqlDataReader
                cmd.CommandText = query;
                cmd.Connection = dbConnect;

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    userPost.UserId = Convert.ToInt32(rd[1]);             
                    userPost.Title = rd[2].ToString();
                    userPost.Category = rd[3].ToString();
                    userPost.Content = rd[4].ToString();
                    if (rd[5] != DBNull.Value)
                    {
                        byte[] image = (byte[])rd[5];
                        userPost.Image = Convert.ToBase64String(image);
                    }
                    
                    userPost.CreatedAt = Convert.ToDateTime(rd[7]);
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message.ToString()); 
            }
            finally
            {
                cmd.Dispose();
                dbConnect.Close();
            }
            return userPost;
        }
    }
}