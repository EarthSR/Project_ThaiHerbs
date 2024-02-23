<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
    <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="True" CssClass="designdrop"></asp:DropDownList>
    <asp:DropDownList ID="DropDownListMonth" runat="server" OnSelectedIndexChanged="DropDownListMonth_SelectedIndexChanged" AutoPostBack="true" CssClass="designdrop"></asp:DropDownList>
    <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" CssClass="designdrop"></asp:DropDownList>
</p>
<p>
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorDay" ControlToValidate="DropDownListDay" ErrorMessage="Please select day" ForeColor="#FF3300" InitialValue="0" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorMonth" ControlToValidate="DropDownListMonth" ErrorMessage="Please select month" ForeColor="#FF3300" InitialValue="0" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorYear" ControlToValidate="DropDownListYear" ErrorMessage="Please select year" ForeColor="#FF3300" InitialValue="0" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
</p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
