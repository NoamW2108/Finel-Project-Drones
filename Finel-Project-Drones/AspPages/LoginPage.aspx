<%@ Page Title="דף כניסה" Language="C#" MasterPageFile="~/AspPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Finel_Project_Drones.AspPages.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/SignUpChecks.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table class="signup">
            <tr>
                <th colspan="3">טופס התחברות לאתר
                </th>
            </tr>
            <tr>
                <td><label for="txtUserName">שם משתמש:</label></td>
                <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                <td width="500px" id="errorUserName" class="error"></td>
            </tr>
            <tr>
                <td><label for="Pass1">סיסמה:</label></td>
                <td><asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox></td>
                <td width="500px" id="errorPass1" class="error"></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="btn_submit" runat="server" Text="התחבר/י" OnClick="btn_submit_Click" />
                    <button type="button" id="btn_reset" onclick="LoginClearFields()">ניקוי שדות הטופס</button>
                </td>
            </tr>
                <td colspan="3">
                    <div class="divider">-------------------------או-------------------------</div>
                </td>
            <tr>    
                <td colspan="3" style="text-align: center; font-weight: bold;">אין לך חשבון?
                    <a href="SignUpPage.aspx">תלחץ כאן להרשמה</a></td>
            </tr>
        </table>
    </form>
</asp:Content>
