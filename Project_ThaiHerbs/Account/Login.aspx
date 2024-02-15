<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content-container">
    <div id="logo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Green_Leaf_Minimalist__Organic_Shop_Logo-removebg-preview.png"
            CssClass="logo-account" />
    </div>
    <div id="login">
        <asp:Label ID="LabelSignIn" runat="server" Text="Sign In" CssClass="login-text"></asp:Label>
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
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Height="26px" Width="170px" CssClass="input"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="ButtonSignIn" runat="server" Text="Sign In"  CssClass="logbut"/>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</div>
</asp:Content>

