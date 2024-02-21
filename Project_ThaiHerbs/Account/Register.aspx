<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content-container">
        <div class="logo">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Green_Leaf_Minimalist__Organic_Shop_Logo-removebg-preview.png" CssClass="auto-style1" Width="225px" />
            <br />
            <br />
        </div>
        <div class="login">
            <asp:Label ID="Label1" runat="server" Text="REGISTER" CssClass="login-text"></asp:Label>
            <br />
            <div class="txtregister">
                <p class="textregister">
                    <asp:Label ID="lbllogin" runat="server" Text="Username" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtusername" runat="server" CssClass="designbox" Height="26px" Width="170px" AutoPostBack="True" OnTextChanged="txtusername_TextChange"></asp:TextBox>
                </p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="Please enter username" ForeColor="#FF3300" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
                <p>
                    <asp:Label ID="lblCheck" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <p class="textregister">
                    <asp:Label ID="txtlogin" runat="server" Text="Password" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtpassword" runat="server" Height="26px" Width="170px" 
                        CssClass="designbox" 
                       ></asp:TextBox>
                </p>
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage="Please enter password" ForeColor="#FF3300" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
                </p>
                <p class="textregister2">
                    <asp:Label ID="lblcomfirm" runat="server" Text="Confirm password" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtconpassword" runat="server" Height="26px" Width="170px" 
                        CssClass="designbox"></asp:TextBox>
                </p>
                <p>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpassword" ErrorMessage="Please enter password" ForeColor="#FF3300" ValidationGroup="RegisterValidation"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:CompareValidator runat="server" ErrorMessage="Password does not match" ControlToCompare="txtpassword" ControlToValidate="txtconpassword" ForeColor="#FF3300" ValidationGroup="RegisterValidation"></asp:CompareValidator>
                </p>
                <p class="textregister3">
                    <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="login-text"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtemail" runat="server" Height="26px" Width="170px" CssClass="designbox" TextMode="Email"></asp:TextBox>
                </p>
                <p>
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Email format is incorrect." ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="RegisterValidation"></asp:RegularExpressionValidator>
                </p>
                <p class="textregister4">
                    <asp:Label ID="lblbirthday" runat="server" Text="Birthday" CssClass="login-text"></asp:Label>
                </p>
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
                <p>
                    <asp:Button ID="ButtonSignIn" runat="server" Text="CONFIRM" CssClass="designbox" OnClick="ButtonSignIn_Click" Height="36px" Width="208px" ValidationGroup="RegisterValidation" />
                </p>
                <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
