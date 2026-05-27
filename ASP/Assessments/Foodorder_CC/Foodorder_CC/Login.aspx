<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foodorder_CC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <h2>Admin Login</h2>

    Username:
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br /><br />

    Password:
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

    <br /><br />

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

</form>
</body>
</html>