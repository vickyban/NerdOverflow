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
        public static List<Post> getPosts(int userId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "SELECT DISTINCT " +
                "p.post_id, p.title, p.category, p.created_at, " +
                "u.user_id, u.username, " +
                "count(c.comment_id) OVER (PARTITION BY p.post_id) AS total_comment " +
                "FROM [Post] p INNER JOIN [User] u " +
                "ON p.user_id = u.user_id " +
                "INNER JOIN [Comment] c " +
                "ON p.post_id = c.post_id " +
                "WHERE p.user_id = @Userid " +
                "ORDER BY p.created_at DESC";
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
                        TotalComments = reader.GetInt32(6),
                        User = new User
                        {
                            UserId = reader.GetInt32(4),
                            Username = reader.GetString(5)
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
    
    }
}