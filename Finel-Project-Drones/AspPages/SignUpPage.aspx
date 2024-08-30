<%@ Page Title="דף הרשמה" Language="C#" MasterPageFile="~/AspPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="Finel_Project_Drones.AspPages.SignUpPage" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;" runat="server" id="res_reg" name="res_reg"></div>
    <form id="Sign_Login" action="SignUpPagePost.aspx" method="post" name="formname" onsubmit="return false;">
        <table class="signup">
            <tr>
                <th colspan="3">טופס הרשמה לאתר</th>
            </tr>

            <tr>
                <td width="150"><label for="txtUserName">שם משתמש:</label></td>
                <td width="520" dir="ltr"><input type="text" id="txtUserName" name="txtUserName" onchange="CheckUserName()" /></td>
                <td id="errorUserName" class="error">&nbsp;</td>
            </tr>

            <tr>
                <td><label for="txtLastName">שם משפחה:</label></td>
                <td dir="ltr"><input type="text" id="txtLastName" name="txtLastName" onchange="CheckLastName()" /></td>
                <td id="errorLastName" class="error"></td>
            </tr>

            <tr>
                <td><label for="Pass1">סיסמה:</label></td>
                <td dir="ltr"><input type="password" id="Pass1" name="Pass1" onchange="CheckPass1()" /></td>
                <td id="errorPass1" class="error"></td>
            </tr>

            <tr>
                <td><label for="Pass2">אימות סיסמה:</label></td>
                <td dir="ltr"><input type="password" id="Pass2" name="Pass2" onchange="CheckPass1()" /></td>
                <td id="errorPass2" class="error"></td>
            </tr>

            <tr>
                <td><label for="PhoneNumber">מספר טלפון:</label></td>
                <td dir="ltr"><input type="text" id="PhoneNumber" name="PhoneNumber" dir="ltr" onchange="CheckPhoneNumber()" /></td>
                <td id="errorPhoneNumber" class="error"></td>
            </tr>

            <tr>
                <td><label for="Email">אימייל:</label></td>
                <td><input type="text" id="Email" name="Email" dir="ltr" onchange="CheckEmail()" /></td>
                <td id="errorEmail" class="error"></td>
            </tr>

            <tr>
                <td><label>מגדר:</label></td>
                <td>
                    <label><input type="radio" name="gender" id="male" value="male" onchange="CheckGender()"/>זכר</label>
                    <label><input type="radio" name="gender" id="female" value="female" onchange="CheckGender()"/>נקבה</label>
                    <label><input type="radio" name="gender" id="other" value="other" onchange="CheckGender()"/>אחר</label>
                </td>
                <td id="errorGender" class="error"></td>
            </tr>

            <tr>
                <td><label>תאריך לידה:</label></td>
                <td><input type="date" id="BirthDay" name="BirthDay" onchange="CheckBirthDay()"/></td>
                <td id="errorBirthDay" class="error"></td>
            </tr>

            <tr>
                <td><label for="Kidnapped">הרחפנים שאת/ה אוהב או מטיס:</label></td>
                <td dir="ltr">
                    <input type="checkbox" name="Inspire1" id="Inspire 1" onclick="chkTotDrones(this.id)"/>Inspire 1
                    <input type="checkbox" name="Inspire2" id="Inspire 2" onclick="chkTotDrones(this.id)"/>Inspire 2
                    <input type="checkbox" name="Inspire3" id="Inspire 3" onclick="chkTotDrones(this.id)"/>Inspire 3 <br />

                    <input type="checkbox" name="Phantom1" id="Phantom 1" onclick="chkTotDrones(this.id)"/>Phantom 1
                    <input type="checkbox" name="Phantom2" id="Phantom 2" onclick="chkTotDrones(this.id)"/>Phantom 2
                    <input type="checkbox" name="Phantom3" id="Phantom 3" onclick="chkTotDrones(this.id)"/>Phantom 3
                    <input type="checkbox" name="Phantom4" id="Phantom 4" onclick="chkTotDrones(this.id)"/>Phantom 4 <br />

                    <input type="checkbox" name="MavicAir1" id="MavicAir 1" onclick="chkTotDrones(this.id)"/>Mavic Air 1
                    <input type="checkbox" name="MavicAir2" id="MavicAir 2" onclick="chkTotDrones(this.id)"/>Mavic Air 2
                    <input type="checkbox" name="MavicAir3" id="MavicAir 3" onclick="chkTotDrones(this.id)"/>Mavic Air 3 <br />

                    <input type="checkbox" name="Mini1" id="Mini 1" onclick="chkTotDrones(this.id)"/>Mini 1
                    <input type="checkbox" name="Mini2" id="Mini 2" onclick="chkTotDrones(this.id)"/>Mini 2
                    <input type="checkbox" name="Mini3" id="Mini 3" onclick="chkTotDrones(this.id)"/>Mini 3 <br />

                    <input type="checkbox" name="FPV1" id="FPV1" onclick="chkTotDrones(this.id)"/>FPV
                    <input type="checkbox" name="Avata" id="Avata" onclick="chkTotDrones(this.id)"/>Avata
                </td>
                <td id="errorDrone" class="error"></td>
            </tr>

            <tr>
                <td><label>אימון טיסה אישי:</label></td>
                <td>
                    <select name="personalFlightTraining" id="personalFlightTraining" onchange="PersonalFlightTraining()">
                        <option value="">בחר אימון טיסה</option>
                        <option value="without">ללא</option>
                        <option value="5Lessons">שיעור ניסיון + 5 שיעורי טיסה</option>
                        <option value="10Lessons">שיעור ניסיון + 10 שיעורי טיסה</option>
                    </select>
                </td>
                <td id="errorPersonalFlightTraining" class="error"></td>
            </tr>

            <tr>
                <td><label>אופן התשלום:</label></td>
                <td>
                    <select name="Payment" id="Payment" onchange="CheckPayment()">
                        <option value="">בחר אופן תשלום</option>
                        <option value="creditCard">כרטיס אשראי</option>
                        <option value="bit">העברה בביט</option>
                        <option value="payBox">העברה בפייבוקס</option>
                    </select>
                </td>
                <td id="errorPayment" class="error"></td>
            </tr>

            <tr>
                <td colspan="3" style="text-align: center;">
                    <button type="button" id="btn_submit" onclick="sendData()">הירשם עכשיו</button>
                    <button type="button" id="btn_reset" onclick="clearFields()">ניקוי שדות הטופס</button>
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <div class="divider">-------------------------או-------------------------</div>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="text-align: center; font-weight: bold;">יש לך חשבון?
                    <a href="LoginPage.aspx">תלחץ כאן לכניסה</a></td>
            </tr>
        </table>
        </form>
        <script src="../Scripts/SignUpChecks.js?ver=1.0.2"></script>
</asp:Content>