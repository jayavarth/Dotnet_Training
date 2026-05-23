<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ques2.aspx.cs" Inherits="Assignment1.Ques2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Product Selection</h2>
        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
        </asp:DropDownList>
        <br /><br />
        <asp:Image ID="imgProduct" runat="server"
            Width="200px"
            Height="200px" />
        <br /><br />
        <asp:Button ID="btnPrice" runat="server"
            Text="Get Price"
            OnClick="btnPrice_Click" />
        <br /><br />
        <asp:Label ID="lblPrice" runat="server"
            Font-Bold="true"
            ForeColor="Blue">
        </asp:Label>
    </form>
</body>
</html>