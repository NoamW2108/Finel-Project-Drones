using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlTypes;

namespace Finel_Project_Drones.AspPages
{
    public partial class SignUpPagePost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int takin = 1;
            divReg.InnerHtml = "אנא המתן";

            string p_username = Request.Form["txtUserName"];
            string p_lastname = Request.Form["txtLastName"];
            string p_password = Request.Form["pass1"];
            string p_phonenumber = Request.Form["PhoneNumber"];
            string p_email = Request.Form["Email"];
            string p_gender = Request.Form["Gender"];
            string p_birthdate = Request.Form["BirthDay"];

            bool p_inspire1;
            if (Request.Form["Inspire1"] == "on")
                p_inspire1 = true;
            else
                p_inspire1 = false;

            bool p_inspire2;
            if (Request.Form["Inspire2"] == "on")
                p_inspire2 = true;
            else
                p_inspire2 = false;

            bool p_inspire3;
            if (Request.Form["Inspire3"] == "on")
                p_inspire3 = true;
            else
                p_inspire3 = false;

            bool p_phantom1;
            if (Request.Form["Phantom1"] == "on")
                p_phantom1 = true;
            else
                p_phantom1 = false;

            bool p_phantom2;
            if (Request.Form["Phantom2"] == "on")
                p_phantom2 = true;
            else
                p_phantom2 = false;

            bool p_phantom3;
            if (Request.Form["Phantom3"] == "on")
                p_phantom3 = true;
            else
                p_phantom3 = false;

            bool p_phantom4;
            if (Request.Form["Phantom4"] == "on")
                p_phantom4 = true;
            else
                p_phantom4 = false;

            bool p_mavicair1;
            if (Request.Form["MavicAir1"] == "on")
                p_mavicair1 = true;
            else
                p_mavicair1 = false;

            bool p_mavicair2;
            if (Request.Form["MavicAir2"] == "on")
                p_mavicair2 = true;
            else
                p_mavicair2 = false;

            bool p_mavicair3;
            if (Request.Form["MavicAir3"] == "on")
                p_mavicair3 = true;
            else
                p_mavicair3 = false;

            bool p_mini1;
            if (Request.Form["Mini1"] == "on")
                p_mini1 = true;
            else
                p_mini1 = false;

            bool p_mini2;
            if (Request.Form["Mini2"] == "on")
                p_mini2 = true;
            else
                p_mini2 = false;

            bool p_mini3;
            if (Request.Form["Mini3"] == "on")
                p_mini3 = true;
            else
                p_mini3 = false;

            bool p_fpv1;
            if (Request.Form["FPV1"] == "on")
                p_fpv1 = true;
            else
                p_fpv1 = false;

            bool p_avata;
            if (Request.Form["Avata"] == "on")
                p_avata = true;
            else
                p_avata = false;

            string p_rsonalflighttraining = Request["personalFlightTraining"];
            string p_payment = Request["Payment"];


            string query = "INSERT INTO UsersTB1 (UserName, LastName, Password, PhoneNumber, Email, Gender, BirthDate, Inspire1, Inspire2, Inspire3, Phantom1, Phantom2 ,Phantom3 ,Phantom4, MavicAir1, MavicAir2, MavicAir3, Mini1, Mini2, Mini3, FPV, Avata, Payment, rsonalFlightTraining) VALUES (@p_username, @p_lastname, @p_password, @p_phonenumber, @p_email, @p_gender, @p_birthdate, @p_inspire1, @p_inspire2, @p_inspire3, @p_phantom1, @p_phantom2, @p_phantom3, @p_phantom4, @p_mavicair1, @p_mavicair2, @p_mavicair3, @p_mini1, @p_mini2, @p_mini3, @p_fpv1, @p_avata, @p_payment, @p_rsonalflighttraining)";

            using (SqlConnection connection = new SqlConnection(Helper.conString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@p_username", p_username);
                command.Parameters.AddWithValue("@p_lastname", p_lastname);
                command.Parameters.AddWithValue("@p_password", p_password);
                command.Parameters.AddWithValue("@p_phonenumber", p_phonenumber);
                command.Parameters.AddWithValue("@p_email", p_email);
                command.Parameters.AddWithValue("@p_gender", p_gender);
                command.Parameters.AddWithValue("@p_birthdate", p_birthdate);

                command.Parameters.AddWithValue("@p_inspire1", p_inspire1);
                command.Parameters.AddWithValue("@p_inspire2", p_inspire2);
                command.Parameters.AddWithValue("@p_inspire3", p_inspire3);
                command.Parameters.AddWithValue("@p_phantom1", p_phantom1);
                command.Parameters.AddWithValue("@p_phantom2", p_phantom2);
                command.Parameters.AddWithValue("@p_phantom3", p_phantom3);
                command.Parameters.AddWithValue("@p_phantom4", p_phantom4);
                command.Parameters.AddWithValue("@p_mavicair1", p_mavicair1);
                command.Parameters.AddWithValue("@p_mavicair2", p_mavicair2);
                command.Parameters.AddWithValue("@p_mavicair3", p_mavicair3);
                command.Parameters.AddWithValue("@p_mini1", p_mini1);
                command.Parameters.AddWithValue("@p_mini2", p_mini2);
                command.Parameters.AddWithValue("@p_mini3", p_mini3);
                command.Parameters.AddWithValue("@p_fpv1", p_fpv1);
                command.Parameters.AddWithValue("@p_avata", p_avata);

                command.Parameters.AddWithValue("@p_payment", p_payment);
                command.Parameters.AddWithValue("@p_rsonalflighttraining", p_rsonalflighttraining);

                try
                {
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        // אף שורה לא הושפעה
                        takin = 20;
                    }
                }
                catch (Exception ex)
                {
                    divReg.InnerHtml = "Error: " + ex.Message;
                    String tmp_res = ex.Message;
                    if (tmp_res.Contains("insert duplicate key"))
                        takin = 30;
                    else
                        takin = 40;
                }
            }

            if(takin==1)
                Response.Redirect($"LoginPage.aspx?ok={takin}");
            else
                Response.Redirect($"SignUpPage.aspx?ok={takin}");
        }
    }
}
