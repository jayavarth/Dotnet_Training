<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuDetails.aspx.cs" Inherits="Foodorder_CC.MenuDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Menu Details</h2>

<table border="1" cellpadding="10">
    <tr>
        <td>Item Name</td>
        <td><asp:Label ID="lblItem" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Category</td>
        <td><asp:Label ID="lblCategory" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Food Type</td>
        <td><asp:Label ID="lblType" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Price</td>
        <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Quantity</td>
        <td><asp:Label ID="lblQty" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Available</td>
        <td><asp:Label ID="lblAvailable" runat="server"></asp:Label></td>
    </tr>

    <tr>
        <td>Created Date</td>
        <td><asp:Label ID="lblDate" runat="server"></asp:Label></td>
    </tr>
</table>

<br />
<asp:HyperLink NavigateUrl="MenuList.aspx" runat="server" Text="Back to List" />
</asp:Content>