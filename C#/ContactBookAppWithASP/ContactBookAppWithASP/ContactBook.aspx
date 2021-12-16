<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactBook.aspx.cs" Inherits="ContactBookAppWithASP.ContactBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Book</title>
    <link href="~/CSS/ContactBook.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <h1>CONTACT BOOK APPLICATION</h1>
            </header>
            <div class="contactBookContainer">
                <div class="leftContainer">
                    <div class="inputField">
                        <label>User Name</label>
                        <input type="text" id="userName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>First Name</label>
                        <input type="text" id="firstName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Last Name</label>
                        <input type="text" id="lastName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Phone Number</label>
                        <input type="text" id="phoneNumber" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Email</label>
                        <input type="text" id="eMail" runat="server" />
                    </div>
                    <div class="inputField">
                        <span></span>
                        <asp:Button class="submitButton" Text="ADD CONTACT" runat="server" ID="AddContact" OnClick="AddContact_Click" />
                        <span></span>
                    </div>
                </div>
                <div class="rightContainer">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
