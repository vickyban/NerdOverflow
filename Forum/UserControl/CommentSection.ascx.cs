using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    /// <summary>
    /// Author: Gia Vien Banh
    /// comment section acts as a placeholder for comment box user controls
    /// </summary>
    public partial class CommentSection : System.Web.UI.UserControl
    {
       public List<Comment> Comments { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        /// <summary>
        /// Render list of post preview control based on the posts property
        /// </summary>
        private void Render()
        {
            if(Comments != null && Comments.Count > 0)
            {
                foreach(var comment in Comments)
                {
                    CommentBox control = (CommentBox)Page.LoadControl("~\\UserControl\\CommentBox.ascx");
                    control.Comment = comment;
                    PlaceHolder1.Controls.Add(control);
                }
            }
        }
    }
}