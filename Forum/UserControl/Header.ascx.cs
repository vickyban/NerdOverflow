using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    public partial class Header : System.Web.UI.UserControl
    {
        public delegate void CallBack(string keywor, string filter, string sort);
        public CallBack CallBackMethod { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}