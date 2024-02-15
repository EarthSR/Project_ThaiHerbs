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
            <asp:Label ID="LabelSignIn" runat="server" Text="Register" CssClass="login-text">
            </asp:Label>
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="product-image">
                        <asp:Label ID="Label4" runat="server" Text="Username" CssClass="login-text"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="txtusername" runat="server" Height="26px" Width="170px" CssClass="input">
                        </asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"
                            ErrorMessage="please enter username" ForeColor="#FF3300">
                        </asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Password" CssClass="login-text"></asp:Label>
                        &nbsp;
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Height="26px"
                        Width="170px" CssClass="input">
                    </asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"
                            ErrorMessage="please enter password" ForeColor="#FF3300">
                        </asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Confirm password" CssClass="login-text">
                        </asp:Label>
                        &nbsp;
                    <asp:TextBox ID="txtconpassword" runat="server" Height="26px" Width="170px" 
                            CssClass="input" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
                        <asp:CompareValidator runat="server" ErrorMessage="password not match" 
                            ForeColor="#FF3300" ControlToCompare="txtpassword" 
                            ControlToValidate="txtconpassword"></asp:CompareValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="E-mail" CssClass="login-text"></asp:Label>
                        &nbsp;
                             <asp:TextBox ID="txtemail" runat="server" TextMode="Email" Height="26px" Width="170px"
                                 CssClass="input"></asp:TextBox>
                        <br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                            ErrorMessage="enter email" ForeColor="#FF3300">
                        </asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator runat="server" 
                            ErrorMessage="Email format is incorrect." ControlToValidate="txtemail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Brithday" CssClass="login-text"></asp:Label>
                        &nbsp;
                        <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:DropDownList ID="DropDownListMonth" runat="server" OnSelectedIndexChanged="DropDownListMonth_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="ButtonSignIn" runat="server" Text="Register" CssClass="logbut" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

