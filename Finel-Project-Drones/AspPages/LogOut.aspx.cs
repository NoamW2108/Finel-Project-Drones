﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finel_Project_Drones.AspPages
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["login"] = null;
            Session["admin"] = "0";
            Response.Redirect("HomePage.aspx");
        }
    }
}