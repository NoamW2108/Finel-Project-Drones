using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;

namespace Finel_Project_Drones.AspPages
{
    public partial class ShowData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTable();
            }
        }

        protected void SortButton_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            string sortBy = sortCriteria.SelectedValue;
            string sortOrder = sortOrderList.SelectedValue;
            string SQLStr = $"SELECT * FROM {Helper.tblName} ORDER BY {sortBy} {sortOrder}";
            DataSet ds = Helper.RetrieveTable(SQLStr);
            DataTable dt = ds.Tables[0];
            string table = Helper.BuildSimpleUsersTable(dt);
            divTable.InnerHtml = table;
        }

        [WebMethod]
        public static void DeleteUser(string userName)
        {
            using (SqlConnection con = new SqlConnection(Helper.conString))
            {
                string sqlStr = $"DELETE FROM {Helper.tblName} WHERE UserName = @UserName";
                using (SqlCommand cmd = new SqlCommand(sqlStr, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }





            //WHERE Gender Like 'f%e'
            //WHERE firstName IN ('Noam', 'Tanya')
            //$"UPDATE {Helper.tblName} SET Email='Noam2@gmail.com' WHERE UserName='Noam'"
        }
    }
}
