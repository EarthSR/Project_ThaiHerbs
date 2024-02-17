<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content-container">
    <div class = "logo">
        <asp:Image ID="logo" runat="server" ImageUrl="~/Image/Green_Leaf_Minimalist__Organic_Shop_Logo-removebg-preview.png" CssClass="logo-account" />
        <br />
        <br />
        <br />
    </div>
    <div class = "login">
        <asp:Label ID="LabelSignIn" runat="server" Text="SIGN IN" CssClass="login-text"></asp:Label>
        <br />
        <br />
        <div class = "log">
                   <p class = "textregister"><asp:Label ID="lblusername" runat="server" Text="Username" CssClass="login-text"></asp:Label></p>
                   <p><asp:TextBox ID="txtusername" runat="server" Height="26px" Width="190px" CssClass="designbox"></asp:TextBox></p>
                   <p class = "textregister"><asp:Label ID="lblpassword" runat="server" Text="Password" CssClass="login-text"></asp:Label></p> 
                   <p><asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Height="26px" Width="190px" CssClass="designbox"></asp:TextBox></p>
                    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                    <br />
                    <p><asp:Button ID ="ButtonSignIn" runat="server" Text="LOGIN"  CssClass="designbox" OnClick="ButtonSignIn_Click" Height="31px" Width="121px" /></p>
                   <p>&nbsp;</p>
                   <p>&nbsp;</p>
                   <p>&nbsp;</p>
                   <p>&nbsp;</p>
            </div>
    </div>
</div>
</asp:Content>

