<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminDelete.aspx.cs" Inherits="AdminDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class = "addminproduct-container"> 
                <div class = "manage-products">
                        <div class = "txt-addminproduct">
                             <h1><asp:Label ID="lblresult" runat="server" Text = "ลบสินค้า" CssClass = "manage-products-title"></asp:Label></h1>
                                <br />
                            </div>
                            <div>
                            <p><h3><asp:Label ID="Label1" runat="server" Text = "ชื่อสินค้า"></asp:Label></h3>
                            <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                            </div>
                            <div>
                              <br />
                              <br />
                              <br />
                             <asp:Button ID="ButtonSignIn" runat="server" Text="ลบสินค้า" Height="30px" Width="100%" cssClass= "btn-manage-products"/>
                            </div>
                        </div>
                    </div>
</asp:Content>

