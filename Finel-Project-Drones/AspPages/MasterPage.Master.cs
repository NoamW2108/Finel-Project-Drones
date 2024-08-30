using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finel_Project_Drones.AspPages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["login"] != null) && (Session["admin"] == "1")) //admin
            {
                ShowData.Visible = true;
                Login.Visible = false;
                LogOut.Visible = true;
                HomePage.Visible = true;
                ComparisonDrones.Visible = true;
                Inspire.Visible = true;
                Phantom.Visible = true;
                FPV.Visible = true;
                Mavic.Visible = true;
                Mini.Visible = true;
                OtherDrones.Visible = true;
                Remote.Visible = true;
                Sim.Visible = true;
                knowledge.Visible = true;
            }
            else if ((Session["login"] != null) && (Session["admin"] == "0")) //no admin
            {
                ShowData.Visible = false;
                Login.Visible = false;
                LogOut.Visible = true;
                HomePage.Visible = true;
                ComparisonDrones.Visible = true;
                Inspire.Visible = true;
                Phantom.Visible = true;
                FPV.Visible = true;
                Mavic.Visible = true;
                Mini.Visible = true;
                OtherDrones.Visible = true;
                Remote.Visible = true;
                Sim.Visible = true;
                knowledge.Visible = true;
            }
            else //no user login
            {
                ShowData.Visible = false;
                Login.Visible = true;
                LogOut.Visible = false;
                HomePage.Visible = true;
                ComparisonDrones.Visible = false;
                Inspire.Visible = true;
                Phantom.Visible = true;
                FPV.Visible = true;
                Mavic.Visible = true;
                Mini.Visible = true;
                OtherDrones.Visible = true;
                Remote.Visible = false;
                Sim.Visible = false;
                knowledge.Visible = false;
            }
        }
    }
}