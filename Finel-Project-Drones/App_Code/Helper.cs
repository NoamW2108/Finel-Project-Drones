using System.Data.SqlClient;
using System.Data;

public class Helper
{
    public const string DBName = "Database2.mdf";
    public const string tblName = "UsersTB1";
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True";
    //public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programs\Projects\Webs\Finel-Project-Drones\Finel-Project-Drones\App_Data\" + DBName + ";Integrated Security=True";
    public static DataSet RetrieveTable(string SQLStr)
    {
        SqlConnection con = new SqlConnection(conString); //התחברות למסד הנתונים
        SqlCommand cmd = new SqlCommand(SQLStr, con); //בניית פקודות SQL
        SqlDataAdapter ad = new SqlDataAdapter(cmd); //בניית DataAdapter
        DataSet ds = new DataSet(); //בניית DataSet לאכסון נתונים מקומי
        ad.Fill(ds, tblName); //טעינת הנתונים ממסד הנתונים DataSet
        return ds;
    }

    public static string BuildSimpleUsersTable(DataTable dt)
    {
        string str = "<table align='center'>";
        str += "<tr>";
        str += "<th>שם משתמש</th><th>שם משפחה</th><th>סיסמה</th><th>מספר טלפון</th><th>אמייל</th><th>מגדר</th><th>תאריך לידה</th><th>רחפן אהוב</th><th>אופן תשלום</th><th>אימון טיסה אישי</th><th>מנהל</th><th>מחיקה</th>";
        str += "</tr>";

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";

            for (int i = 0; i < 7; i++)
            {
                if (dt.Columns[i].ColumnName == "BirthDate")
                {
                    string strDate = row[dt.Columns[i]].ToString();
                    if (!string.IsNullOrEmpty(strDate) && strDate.Length >= 10)
                    {
                        strDate = strDate.Substring(0, 10);
                        strDate = strDate.Substring(8, 2)+"/"+ strDate.Substring(5, 2) + "/" + strDate.Substring(0, 4);
                    }
                    str += "<td>" + strDate + "</td>";
                }
                else if (dt.Columns[i].ColumnName == "Gender")
                {
                    if (row[dt.Columns[i]].ToString() == "female")
                    {
                        str += "<td>נקבה</td>";
                    }
                    else if(row[dt.Columns[i]].ToString() == "male")
                    {
                        str += "<td>זכר</td>";
                    }
                    else
                    {
                        str += "<td>אחר</td>";
                    }
                }
                else if (dt.Columns[i].ColumnName == "rsonalFlightTraining")
                {
                    str += "<td style='direction: ltr;'>" + row[dt.Columns[i]].ToString() + "</td>";
                }
                else
                {
                    str += "<td style='direction: ltr;'>" + row[dt.Columns[i]] + "</td>";
                }
            }

            str += "<td style='direction: ltr;'>";
            string[] arrActors = { "Inspire1", "Inspire2", "Inspire3", "Phantom1", "Phantom2", "Phantom3", "Phantom4", "MavicAir1", "MavicAir2", "MavicAir3", "Mini1", "Mini2", "Mini3", "FPV", "Avata" };
            string strNames = "";

            for (int i = 7; i <= 21; i++)
            {
                if (i < 22 && row[dt.Columns[i]].ToString() == "True")
                {
                    strNames += arrActors[i - 7] + " , ";
                }
            }

            str += strNames + "</td>";
            str += "<td>" + row[dt.Columns[22]] + "</td>";
            str += "<td>" + row[dt.Columns[23]] + "</td>";
            str += "<td>" + (row[dt.Columns[24]].ToString() == "True" ? "מנהל" : "משתמש") + "</td>";

            str += $"<td><span style='color:red;cursor:pointer;' onclick='deleteUser(\"{row["UserName"]}\")'>&cross;</td>";

            str += "</tr>";
        }

        str += "</table>";
        return str;
    }
}