using Forum.Models;
using Forum.Repositories;
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
    /// Comment box user control
    /// </summary>
    public partial class CommentBox : System.Web.UI.UserControl
    {
        public Comment Comment { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
            if (Session["UserId"] == null)
                panelActions.Visible = false;
            else
                panelActions.Visible = true;
        }

        private void Render()
        {
            fcommentId.Value = Comment.CommentId.ToString();
            fuserId.Value = Comment.UserId.ToString();
            fpostId.Value = Comment.PostId.ToString();
            lblAuthor.Text = Comment.Users.Username;
            lblCreatedAt.Text = Comment.CreatedAt.ToString();
            //lblContent.Text = Comment.Content;
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

        protected void btnSendReply_Click(object sender, EventArgs e)
        {
            int parentId = Convert.ToInt32(fcommentId.Value);
            int postId = Convert.ToInt32(fpostId.Value);
            string content = txtReply.Text;
            int userId = Convert.ToInt32(Session["UserId"].ToString());
            Comment comment = new Comment { PostId = postId, Content = content, ParentId = parentId, UserId = userId };
            CommentRepo.InsertComment(comment);
            Response.Redirect($"/posts/{postId}/");
        }
    }
}