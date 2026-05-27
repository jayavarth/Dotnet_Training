<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="Foodorder_CC.AddEditMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Add / Edit Menu</h2>

Item Name:
<asp:TextBox ID="txtItem" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator 
    ControlToValidate="txtItem"
    runat="server" 
    ErrorMessage="Item Name is required"
    ForeColor="Red" />

<asp:RegularExpressionValidator 
    ControlToValidate="txtItem"
    ValidationExpression="^[a-zA-Z ]+$"
    runat="server"
    ErrorMessage="Only alphabets allowed"
    ForeColor="Red" />
<br /><br />

Category:
<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator 
    ControlToValidate="txtCategory"
    runat="server" 
    ErrorMessage="Category is required"
    ForeColor="Red" />
<br /><br />

Food Type:
<asp:DropDownList ID="ddlType" runat="server">
    <asp:ListItem Text="Select Type" Value=""></asp:ListItem>
    <asp:ListItem Text="Veg" Value="Veg"></asp:ListItem>
    <asp:ListItem Text="Non-Veg" Value="Non-Veg"></asp:ListItem>
</asp:DropDownList>

<asp:CompareValidator 
    ControlToValidate="ddlType"
    ValueToCompare=""
    Operator="NotEqual"
    runat="server"
    ErrorMessage="Please select Food Type"
    ForeColor="Red" />
<br /><br />
Price:
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator 
    ControlToValidate="txtPrice"
    runat="server"
    ErrorMessage="Price is required"
    ForeColor="Red" />

<asp:RangeValidator 
    ControlToValidate="txtPrice"
    MinimumValue="1"
    MaximumValue="1000"
    Type="Double"
    runat="server"
    ErrorMessage="Price must be between 1 and 1000"
    ForeColor="Red" />
<br /><br />

Quantity:
<asp:TextBox ID="txtQty" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator 
    ControlToValidate="txtQty"
    runat="server"
    ErrorMessage="Quantity is required"
    ForeColor="Red" />

<asp:CompareValidator 
    ControlToValidate="txtQty"
    Operator="DataTypeCheck"
    Type="Integer"
    runat="server"
    ErrorMessage="Quantity must be a number"
    ForeColor="Red" />
<br /><br />

<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

<br /><br />

<asp:ValidationSummary 
    runat="server"
    HeaderText="Please fix the following errors:"
    ForeColor="Red" />
<asp:ValidationSummary runat="server" ForeColor="Red" />
</asp:Content>