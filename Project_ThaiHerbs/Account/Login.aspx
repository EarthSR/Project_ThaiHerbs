<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content-container">
        <div class ="box-login">
        <div class="logo">
            <asp:Image ID="logo" runat="server" ImageUrl="~/Image/Green_Leaf_Minimalist__Organic_Shop_Logo-removebg-preview.png"
                CssClass="logo-account" />
            <br />
            <br />
            <br />
        </div>
        
        <div class="login">
            <h1><asp:Label ID="LabelSignIn" runat="server" Text="LOGIN" CssClass="login-text"></asp:Label></h1>
            <br />
            <div class="log">
                <p class="textregister">
                    <asp:Label ID="lblusername" runat="server" Text="Username" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtusername" runat="server" Height="26px" Width="286px" CssClass="designbox"></asp:TextBox>
                </p>
                <p>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Enter username" ControlToValidate="txtusername" ForeColor="Red" ValidationGroup="LoginValidation" ></asp:RequiredFieldValidator>
                </p>
                <p class="textregister">
                    <asp:Label ID="lblpassword" runat="server" Text="Password" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Height="26px" Width="286px" CssClass="designbox"></asp:TextBox>
                </p>
                <p>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtpassword" ForeColor="Red" ValidationGroup="LoginValidation"></asp:RequiredFieldValidator>
                </p>
                <p>
                   <asp:Button ID="ButtonSignIn" runat="server" Text="LOGIN" CssClass="ButtonSignIn" OnClick="ButtonSignIn_Click" Height="36px" Width="208px" ValidationGroup="LoginValidation" />
                    <br />
                    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                </p>
                <br />
                <br />
                <asp:LinkButton ID="lbl1" runat="server" Text="Creat New Account"/>
                </div>
                <br />
                <br />
                <br />
                </div>
            </div>
            </div>
</asp:Content>
