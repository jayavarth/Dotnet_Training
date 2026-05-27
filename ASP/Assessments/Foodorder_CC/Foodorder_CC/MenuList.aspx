<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Foodorder_CC.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Menu Items</h2>

    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="MenuId">

        <Columns>
            <asp:BoundField DataField="MenuId" HeaderText="ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="FoodType" HeaderText="Food Type" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="AvailableQuantity" HeaderText="Quantity" />
            <asp:BoundField DataField="IsAvailable" HeaderText="Available" />
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />

            <asp:HyperLinkField Text="View"
                DataNavigateUrlFields="MenuId"
                DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

            <asp:HyperLinkField Text="Edit"
                DataNavigateUrlFields="MenuId"
                DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server"
                        Text="Delete"
                        CommandArgument='<%# Eval("MenuId") %>'
                        OnCommand="DeleteItem"
                        OnClientClick="return confirm('Are you sure to delete?');">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>