using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Forum.Helpers
{
    public class PasswordHelper
    {
        public static string decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string str = System.Text.Encoding.UTF8.GetString(mybyte);
            return str;
        }
        public static string Encrypted(string str)
        {
            string msg = "";
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}