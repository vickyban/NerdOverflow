using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    public partial class PostPreview : System.Web.UI.UserControl
    {
        public Post Post { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}