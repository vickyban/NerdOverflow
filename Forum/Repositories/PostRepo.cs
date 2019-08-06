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
        public static List<Post> getPostsByAuthor(int userId, List<string> filters, string orderBy)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "SELECT DISTINCT " +
                "p.post_id, p.title, p.category, p.created_at, p.status, " +
                "u.user_id, u.username, " +
                "count(c.comment_id) OVER (PARTITION BY p.post_id) AS total_comment " +
                "FROM [Post] p INNER JOIN [User] u " +
                "ON p.user_id = u.user_id " +
                "LEFT OUTER JOIN [Comment] c " +
                "ON p.post_id = c.post_id " +
                "WHERE p.user_id = " + userId + " " +
                "AND p.status IN (" + string.Join(", ", filters) + ") " +
                "ORDER BY p.created_at " + orderBy;
            cmd.CommandText = query;

            return getPosts(cmd);
        }

        public static List<Post> getPosts(string keyword, string filter, string orderBy)
        {
            SqlCommand cmd = new SqlCommand();
            string query = "SELECT DISTINCT " +
                "p.post_id, p.title, p.category, p.created_at, p.status, " +
                "u.user_id, u.username, " +
                "count(c.comment_id) OVER (PARTITION BY p.post_id) AS total_comment, " +
                "LEFT(p.content, 100) as content " +
                "FROM [Post] p INNER JOIN [User] u " +
                "ON p.user_id = u.user_id " +
                "LEFT OUTER JOIN [Comment] c " +
                "ON p.post_id = c.post_id " +
                "WHERE p.status IN ('published','review') " +
                (keyword != "" ? "AND p.title LIKE '%'+ @Keyword + '%' ": "") + 
                (filter != "" ? $"AND p.category IN ({filter}) ": "") + 
                "ORDER BY p.created_at " + orderBy;
            if(keyword != "") cmd.Parameters.AddWithValue("Keyword", keyword);
            cmd.CommandText = query;
            return getPosts(cmd,true);
        }

        public static List<Post> getPosts(SqlCommand cmd, bool withContent = false)
        {
            SqlConnection con = new SqlConnection(connectionString);
            cmd.Connection = con;
            List<Post> posts = new List<Post>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //reader.Read();
                    Post post = new Post
                    {
                        PostId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Category = reader.GetString(2),
                        CreatedAt = reader.GetDateTime(3),
                        Status = reader.GetString(4),
                        TotalComments = reader.GetInt32(7),
                        UserId = reader.GetInt32(5),
                        User = new User
                        {
                            UserId = reader.GetInt32(5),
                            Username = reader.GetString(6)
                        }
                    };
                    if (withContent) post.Content = HttpUtility.HtmlDecode((reader.GetString(8))); 
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
    }
}