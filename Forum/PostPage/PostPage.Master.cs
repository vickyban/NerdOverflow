using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.PostPage
{
    public partial class PostPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Add("userId", 2);
            this.Session.Add("isAdmin", true);
        }
    }
}