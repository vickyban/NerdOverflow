using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.Repositories
{
    public class UserRepo:BaseRepo
    {
        public static string GetUserPassword(int userId)
        {
            string query = "Select password FROM [User] WHERE user_id = " + userId;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            string encryptPass = null;
            try
            {
                con.Open();
                encryptPass = cmd.ExecuteScalar().ToString();
            }catch(Exception ex) { }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return encryptPass;
        }

        public static void UpdatePassword(int userId, string password)
        {
            string query = "UPDATE [USER] SET password = @Password WHERE user_id = " + userId;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("Password", password);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        public static void SaveImage(int userId, byte[] image)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "UPDATE [User] SET profile_img = @Image WHERE user_id = @Id";
            cmd.CommandText = query;
            cmd.Parameters.Add("Image", SqlDbType.VarBinary).Value = image;
            cmd.Parameters.AddWithValue("Id", userId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception ex) { }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        public static User GetUser(int userId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            string query = "SELECT username, isAdmin, profile_img, created_at " +
                "FROM [User] WHERE user_id = @Id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("Id", userId);
            User user = null;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //reader.Read();
                    user = new User
                    {
                        UserId = userId,
                        Username = reader.GetString(0),
                        IsAdmin = reader.GetBoolean(1),
                        CreatedAt = reader.GetDateTime(3)
                    };

                    if(reader[2] != null)
                    {
                        user.Profile_img = (byte[])reader[2];
                    }
                }
                reader.Close();
            }catch(Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return user;

        }

    }
}