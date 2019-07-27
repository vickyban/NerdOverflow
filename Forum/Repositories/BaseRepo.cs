﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Repositories
{
    public abstract class BaseRepo
    {
        protected static string connectionString = System.Web.Configuration
                .WebConfigurationManager
                .ConnectionStrings["CollegeDBConnectionString"]
                .ToString();
    }
}