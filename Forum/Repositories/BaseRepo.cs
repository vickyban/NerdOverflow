using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Repositories
{

    /// <summary>
    /// Author: Gia Vien Banh
    /// Base class for all Repo classes
    /// </summary>
    public abstract class BaseRepo
    {
        protected static string connectionString = System.Web.Configuration
                .WebConfigurationManager
                .ConnectionStrings["ForumConnectionString"]
                .ToString();
    }
}