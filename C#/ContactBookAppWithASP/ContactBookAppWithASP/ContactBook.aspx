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
                        <input type="text" id="txtUserName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>First Name</label>
                        <input type="text" id="txtFirstName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Last Name</label>
                        <input type="text" id="txtLastName" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Phone Number</label>
                        <input type="text" id="txtPhoneNumber" runat="server" />
                    </div>
                    <div class="inputField">
                        <label>Email</label>
                        <input type="text" id="txtEMail" runat="server" />
                    </div>
                    <div class="inputField">
                        <span></span>
                        <asp:Button class="submitButton" Text="ADD CONTACT" runat="server" ID="btnAddContact" OnClick="BtnAddContact_Click" />
                        <asp:Button class="submitButton" Text="SAVE CONTACT" runat="server" ID="btnEditContact" Visible="false" OnClick="BtnEditContact_Click" />
                    </div>
                </div>
                <div class="rightContainer">
                    <asp:GridView ID="gvContactBookTable" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactBookTable_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" Text='<% #Eval("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" Text='<% #Eval("FirstName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" Text='<% #Eval("LastName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" Text='<% #Eval("PhoneNumber") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMail">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMail" Text='<% #Eval("EMail") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EDIT">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditContact" CommandArgument='<%# Eval("Name") + "," + Eval("FirstName") + "," + Eval("LastName") + "," + Eval("PhoneNumber") + "," + Eval("EMail") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DELETE">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteContact" CommandArgument='<% #Eval("PhoneNumber") %>' OnClientClick="return confirm('Do you want to delete?')"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
