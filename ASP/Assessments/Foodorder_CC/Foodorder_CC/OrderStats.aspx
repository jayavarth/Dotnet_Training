<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="Foodorder_CC.OrderStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Order Statistics</h2>

    <h3>Application State</h3>

    Total Visitors:
    <asp:Label ID="lblVisitors" runat="server" ForeColor="Blue"></asp:Label>
    <br /><br />

    Active Users:
    <asp:Label ID="lblActive" runat="server" ForeColor="Blue"></asp:Label>
    <br /><br />

    <hr />

    <h3>Category-wise Food Summary (Cached)</h3>

    <asp:GridView ID="gvStats" runat="server"></asp:GridView>

</asp:Content>
