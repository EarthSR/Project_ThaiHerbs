<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminShipping.aspx.cs" Inherits="AdminSell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class = "addminproduct-container"> 
                <div class = "manage-products">
                    <div class = "txt-addminproduct"> 
                        <h2><asp:Label ID="lblresult" runat="server" Text = "สินค้าที่ต้องยืนยันการสั่งซื้อ" CssClass = "manage-products-title"></asp:Label></h2>
                        <br />
                        <p>
                            <asp:Label runat="server" ID="lblshow"></asp:Label>
                        
                        <div>
                        <p><h3><asp:Label ID="Label1" runat="server" Text = "กรอกorderid"></asp:Label></h3>
                        <asp:TextBox ID="txtid" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        </div>

                        <div>
                            <h3><asp:Label ID="Label3" runat="server" Text = "ขนส่ง"></asp:Label></h3>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="34px" Width="100%">
                            <asp:ListItem>Flash Expless</asp:ListItem>
                            <asp:ListItem>Kery Expless</asp:ListItem>
                            <asp:ListItem>ไปรษณีย์ไทย</asp:ListItem>
                            </asp:DropDownList></p>
                        </div>


                         <div class = "btnOrdercon">
                        <br />
                             <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                            <asp:Button ID="ButtonSignIn" runat="server" Text="ยืนยันออเดอร์" Height="30px" s
                                 Width="100%" cssClass= "btn-manage-products" OnClick="ButtonSignIn_Click"/>
                        </div>






                </div>
                    </div>
                        </div>
</asp:Content>

