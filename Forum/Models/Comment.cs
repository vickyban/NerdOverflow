using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Users { get; set; }
        public virtual Comment Parent { get; set; }

        public int Level { get; set; }
        public List<Comment> Children { get; set; } = new List<Comment>();
    }
}