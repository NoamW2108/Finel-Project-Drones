<%@ Page Title="" Language="C#" MasterPageFile="~/AspPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShowData.aspx.cs" Inherits="Finel_Project_Drones.AspPages.ShowData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <style>
        .sorting-section {
            float: right;
            margin-top: 20px;
        }

        .sorting-section select,
        .sorting-section label {
            display: inline-block;
            margin: 0;
        }

        .sort-button {
            border: none;
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            font-size: 20px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .sort-button:hover {
            background-color: #45a049;
            filter: brightness(110%);
            -webkit-filter: brightness(110%);
        }
    </style>

    <script type="text/javascript">
        function deleteUser(userName) {
            if (confirm("האם אתה בטוח שאתה רוצה למחוק את המשתמש?")) {
                var xhr = new XMLHttpRequest();
                xhr.open("POST", "ShowData.aspx/DeleteUser", true);
                xhr.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        alert("משתמש נמחק בהצלחה.");
                        location.reload();
                    }
                };
                xhr.send(JSON.stringify({ userName: userName }));
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="font-size: 20px;">
        <div class="sorting-section">
            <label for="sortCriteria">מיון לפי:</label>
            <asp:DropDownList ID="sortCriteria" style="direction:rtl;BORDER:1px #ced4da solid;color:#333;font-size:16px;text-align:right;padding-right:5px;height:36px;width:100%;-webkit-tap-highlight-color:transparent;outline:none" runat="server">
                <asp:ListItem Text="שם משתמש" Value="UserName" />
                <asp:ListItem Text="שם משפחה" Value="LastName" />
                <asp:ListItem Text="מגדר" Value="Gender" />
                <asp:ListItem Text="תאריך לידה" Value="BirthDate" />
                <asp:ListItem Text="אופן תשלום" Value="Payment" />
                <asp:ListItem Text="אימון טיסה אישי" Value="rsonalFlightTraining" />
                <asp:ListItem Text="מנהל" Value="Admin" />
            </asp:DropDownList>

            <asp:RadioButtonList ID="sortOrderList" runat="server">
                <asp:ListItem Text="סדר עולה" Value="ASC" Selected="True" />
                <asp:ListItem Text="סדר יורד" Value="DESC" />
            </asp:RadioButtonList>

            <asp:Button ID="sortButton" runat="server" Text="Sort" OnClick="SortButton_Click" CssClass="sort-button" />
        </div>
    </form>

    <div runat="server" id="divTable" name="divTable"></div>
    <!--<div runat="server" id="divTable222"></div>-->
    <!--  divTable222.innerHTML = "hello";  -->
  
</asp:Content>
