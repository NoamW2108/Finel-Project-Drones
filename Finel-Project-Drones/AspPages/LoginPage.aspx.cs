using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finel_Project_Drones.AspPages
{
    public partial class LoginPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = Pass1.Text.Trim();

            var userValidationResult = ValidateUser(userName, password);

            if (userValidationResult != null && userValidationResult.Item1 != null)
            {
                Session["login"] = userValidationResult.Item1;
                if (userValidationResult.Item2 == true)
                {
                    Session["admin"] = "1";
                }
                else
                {
                    Session["admin"] = "0";
                }
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Session["login"] = "";
                Session["admin"] = "";
                Response.Write("<script>alert('שם משתמש או סיסמה לא חוקיים');</script>");
            }
        }

        private Tuple<string, bool> ValidateUser(string userName, string password)
        {
            string query = $"SELECT UserName, Admin FROM {Helper.tblName} WHERE UserName = @UserName AND Password = @Password";
            string tempUser = null;
            bool tempAdmin = false;

            using (SqlConnection con = new SqlConnection(Helper.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tempUser = reader["UserName"].ToString();
                            tempAdmin = (bool)reader["Admin"];
                        }
                    }

                    con.Close();
                }
            }

            return Tuple.Create(tempUser, tempAdmin);
        }
    }
}
