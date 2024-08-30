using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finel_Project_Drones.AspPages
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = Request.QueryString["ok"];
            if(res == "20")
            {
                res_reg.InnerHtml = "ההרשמה נכשלה! אף שורה לא הושפעה.";
            }
            else if (res == "30")
            {
                res_reg.InnerHtml = "ההרשמה נכשלה - ישנה כפילות של שם המשתמש!";
            }
            else if (res == "40")
            {
                res_reg.InnerHtml = "ההרשמה נכשלה!" + (res);
            }
            else
            {
                res_reg.InnerHtml = "";
            }
        }
    }
}