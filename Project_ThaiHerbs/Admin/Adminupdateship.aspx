<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="Adminupdateship.aspx.cs" Inherits="Admin_Adminupdateship" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class = "addminproduct-container"> 
                <div class = "manage-products">
                    <div class = "txt-addminproduct"> 
                        <h2><asp:Label ID="lblresult" runat="server" Text = "อัปเดตการสั่งซื้อ" CssClass = "manage-products-title"></asp:Label></h2>
                        <br />
                        <p>
                            <asp:Label runat="server" ID="lblshow"></asp:Label>
                        
                        <div>
                        <p><h3><asp:Label ID="Label1" runat="server" Text = "กรอกorderid"></asp:Label></h3>
                        <asp:TextBox ID="txtid" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        </div>


                         <div class = "btnOrdercon">
                        <br />
                             <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                            <asp:Button ID="ButtonSignIn" runat="server" Text="อัปเดตออเดอร์" Height="30px" s
                                 Width="100%" cssClass= "btn-manage-products" OnClick="ButtonSignIn_Click"/>
                        </div>






                </div>
                    </div>
                        </div>
</asp:Content>


