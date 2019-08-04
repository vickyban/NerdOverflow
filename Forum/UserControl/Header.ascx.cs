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
        public delegate void CallBack(List<Post> posts);
        public CallBack CallBackMethod { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sort = dlistSortBy.SelectedValue;
            string filter = null;
            if (!cbAll.Checked)
            {
                IEnumerable<string> filters = panel1.Controls.Cast<Control>()
                    .Where(c => c is CheckBox && ((CheckBox)c).Checked)
                    .Select(c => ((CheckBox)c).Text.ToLower() != "other" ? $"'{((CheckBox)c).Text}'" : $"'{txtOther.Text}'");
                filter =  string.Join(",",filters) ;
            }
            string keyword = txtSearch.Text;
            if (keyword == "")
                keyword = null;

            //string url = $"/posts/?search={txtSearch.Text}&filter={filter}&sort={sort}";
            //Response.Redirect(url);
            //string sort = Request.QueryString["sort"];
            //if(sort == null ) sort = "DESC";
            List<Post> posts = PostRepo.getPosts(filter, keyword, sort);
            CallBackMethod(posts);
        }
    }
}