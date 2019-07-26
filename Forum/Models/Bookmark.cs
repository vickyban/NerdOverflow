using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Bookmark
    {

        public int BookmarkId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User Users { get; set; }
        public virtual Post Posts { get; set; }
    }
}