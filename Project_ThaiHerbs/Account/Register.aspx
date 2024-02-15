<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content-container">
        <div id="logo">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Green_Leaf_Minimalist__Organic_Shop_Logo-removebg-preview.png"
                CssClass="logo-account" />
        </div>
        <div id="login">
            <asp:Label ID="LabelSignIn" runat="server" Text="Register" CssClass="login-text"></asp:Label>
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="product-image">
                        <asp:Label ID="Label4" runat="server" Text="Username" CssClass="login-text"></asp:Label>
                        &nbsp;
                    <asp:TextBox ID="TextBoxUsername" runat="server" Height="26px" Width="170px" CssClass="input"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Password" CssClass="login-text"></asp:Label>
                        &nbsp;
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Height="26px"
                        Width="170px" CssClass="input"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Confirm password" CssClass="login-text"></asp:Label>
                        &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="170px" CssClass="input"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="E-mail" CssClass="login-text"></asp:Label>
                        &nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Height="26px" Width="170px"
                        CssClass="input"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Brithday" CssClass="login-text"></asp:Label>
                        &nbsp;
                        <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:DropDownList ID="DropDownListMonth" runat="server" OnSelectedIndexChanged="DropDownListMonth_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="ButtonSignIn" runat="server" Text="Sign In" CssClass="logbut" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

