<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Insert your details :</h2>

        <table border="0" cellpadding="5">

            <tr>
                <td>Name :</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        ControlToValidate="txtName"
                        ErrorMessage="Name required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Family Name :</td>
                <td>
                    <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvFamily" runat="server"
                        ControlToValidate="txtFamily"
                        ErrorMessage="Family name required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:CustomValidator ID="cvName" runat="server"
                        ControlToValidate="txtFamily"
                        OnServerValidate="ValidateName"
                        ErrorMessage="Name and Family Name must be different"
                        ForeColor="Red">
                    </asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>Address :</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                        ControlToValidate="txtAddress"
                        ErrorMessage="Address required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:RegularExpressionValidator ID="revAddress" runat="server"
                        ControlToValidate="txtAddress"
                        ValidationExpression=".{2,}"
                        ErrorMessage="At least 2 letters"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>City :</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                        ControlToValidate="txtCity"
                        ErrorMessage="City required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:RegularExpressionValidator ID="revCity" runat="server"
                        ControlToValidate="txtCity"
                        ValidationExpression=".{2,}"
                        ErrorMessage="At least 2 letters"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>Zip Code :</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server"
                        ControlToValidate="txtZip"
                        ErrorMessage="Zip Code required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:RegularExpressionValidator ID="revZip" runat="server"
                        ControlToValidate="txtZip"
                        ValidationExpression="^\d{5}$"
                        ErrorMessage="Zip code must be 5 digits"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>Phone :</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server"
                        ControlToValidate="txtPhone"
                        ErrorMessage="Phone required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:RegularExpressionValidator ID="revPhone" runat="server"
                        ControlToValidate="txtPhone"
                        ValidationExpression="^\d{2,3}-\d{7}$"
                        ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>E-mail :</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Email required"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <br />

                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression="^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$"
                        ErrorMessage="Invalid Email"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnCheck" runat="server"
                        Text="Check"
                        OnClick="btnCheck_Click" />
                </td>
            </tr>

        </table>

        <br />

        <asp:ValidationSummary ID="ValidationSummary1"
            runat="server"
            HeaderText="Validation Summary"
            ForeColor="Red"
            ShowMessageBox="true"
            ShowSummary="true" />

        <br />

        <asp:Label ID="lblResult" runat="server"></asp:Label>

    </form>
</body>
</html>