using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    public partial class CommentBox : System.Web.UI.UserControl
    {
        public Comment Comment { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            fcommentId.Value = Comment.CommentId.ToString();
            fuserId.Value = Comment.UserId.ToString();
            lblAuthor.Text = Comment.Users.Username;
            lblCreatedAt.Text = Comment.CreatedAt.ToString();
            lblContent.Text = Comment.Content;
            List<Comment> replies = Comment.Children;
            if(replies != null && replies.Count > 0)
            {
                foreach(var reply in replies)
                {
                    CommentBox control = (CommentBox)Page.LoadControl("~\\UserControl\\CommentBox.ascx");
                    control.Comment = reply;
                    PlaceHolder1.Controls.Add(control);
                }
            }
        }
    }
}