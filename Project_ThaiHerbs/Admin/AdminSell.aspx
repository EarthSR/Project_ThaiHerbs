<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminSell.aspx.cs" Inherits="AdminSell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class = "addminproduct-container"> 
                <div class = "manage-products">
                    <div class = "txt-addminproduct"> 
                        <h2><asp:Label ID="lblresult" runat="server" Text = "สินค้าที่ต้องยืนยันการสั่งซื้อ" CssClass = "manage-products-title"></asp:Label></h2>
                        <br />
                        <p><h3>รายการที่ <a>1</a></h3>
                        
                            
                        <div>
                        <p><h3><asp:Label ID="Label1" runat="server" Text = "ชื่อสินค้า"></asp:Label></h3>
                        <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        </div>

                        <div>
                        <p><h3><asp:Label ID="Label2" runat="server" Text = "จำนวนสินค้า"></asp:Label></h3>
                        <asp:TextBox ID="TextBox2" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        </div>

                        <div>
                        <p><h3><asp:Label ID="Label3" runat="server" Text = "ขนส่ง"></asp:Label></h3>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="34px" Width="100%">
                            <asp:ListItem>Flash Expless</asp:ListItem>
                            <asp:ListItem>Kery Expless</asp:ListItem>
                            <asp:ListItem>ไปรษณีย์ไทย</asp:ListItem>
                            </asp:DropDownList></p>
                        </div>


                         <div class = "btnOrdercon">
                        <br />
                        <br />
                        <br />
                            <p><asp:Button ID="Button1" runat="server" Text="ลบออเดอร์" Height="30px" Width="100%" cssClass= "btn-manage-products"/></p>     
                            <asp:Button ID="ButtonSignIn" runat="server" Text="ยืนยันออเดอร์" Height="30px" Width="100%" cssClass= "btn-manage-products"/>
                        </div>






                </div>
                    </div>
                        </div>
</asp:Content>

