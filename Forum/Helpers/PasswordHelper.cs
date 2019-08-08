using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Forum.Helpers
{
    /// <summary>
    /// Author: Haoyue Wang
    /// Contain methods to encode and decode passwords
    /// </summary>
    public class PasswordHelper
    {
        /// <summary>
        /// Decode text 
        /// </summary>
        /// <param name="text">encoded text to be decode</param>
        /// <returns>decode text</returns>
        public static string decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string str = System.Text.Encoding.UTF8.GetString(mybyte);
            return str;
        }

        /// <summary>
        /// Encode text
        /// </summary>
        /// <param name="text">text to be encode</param>
        /// <returns>encode text</returns>
        public static string Encrypted(string text)
        {
            string msg = "";
            byte[] encode = new byte[text.Length];
            encode = Encoding.UTF8.GetBytes(text);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}