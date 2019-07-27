using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Forum.Models;

namespace Forum.Repositories
{
    public class BookmarkRepo:BaseRepo
    {
        public static List<Bookmark> GetBookmarks(int userId, string orderBy)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "SELECT DISTINCT " +
                "b.bookmark_id, b.post_id, b.user_id, " +
                "p.title, p.category, p.created_at, " +
                "u.user_id, u.username, " +
                "count(c.comment_id) OVER (PARTITION BY p.post_id) AS total_comment " +
                "FROM [Bookmark] b INNER JOIN [Post] p " +
                "ON b.post_id = p.post_id " +
                "INNER JOIN [User] u " +
                "ON p.user_id = u.user_id " +
                "LEFT OUTER JOIN [Comment] c " +
                "ON p.post_id = c.post_id " +
                "WHERE b.user_id = @Userid " +
                "ORDER BY p.created_at " + orderBy;
            SqlParameter param = new SqlParameter("Userid", userId);
            cmd.CommandText = query;
            cmd.Parameters.Add(param);
            List<Bookmark> bookmarks = new List<Bookmark>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    reader.Read();
                    int r = reader.GetInt32(0);
                    Bookmark bookmark = new Bookmark
                    {
                        BookmarkId = reader.GetInt32(0),
                        PostId = reader.GetInt32(1),
                        UserId = reader.GetInt32(2),
                        Post = new Post
                        {
                            PostId = reader.GetInt32(1),
                            Title = reader.GetString(3),
                            Category = reader.GetString(4),
                            CreatedAt = reader.GetDateTime(5),
                            TotalComments = reader.GetInt32(8),
                            User = new User
                            {
                                UserId = reader.GetInt32(6),
                                Username = reader.GetString(7)
                            }
                        },
                        User = new User
                        {
                            UserId = reader.GetInt32(2),
                        }

                    };
                    bookmarks.Add(bookmark);
                }
                reader.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return bookmarks;
        }

        public static void DeleteBookmark(int bookmarkId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "DELETE FROM [Bookmark] WHERE bookmark_id = @ID";
            cmd.CommandText = query;
            SqlParameter param = new SqlParameter("ID", bookmarkId);
            cmd.Parameters.Add(param);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

    }
}