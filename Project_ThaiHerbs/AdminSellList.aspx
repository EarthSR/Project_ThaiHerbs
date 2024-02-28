<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminSellList.aspx.cs" Inherits="AdminSellList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct"
                           <p><h1>สินค้าที่ต้องกดยืนยัน</h1></p>

                        <div>
                            <p>1.<asp:LinkButton ID="support" runat="server" Text="ชื่อสินค้า(1)"/> : เวลาที่สั่ง</p>    
                        </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <p><asp:Button ID="Button1" runat="server" Text="ลบออเดอร์ทั้งหมด" Height="30px" Width="100%" cssClass= "btn-manage-products"/></p>     
                            <asp:Button ID="ButtonSignIn" runat="server" Text="ยืนยันออเดอร์ทั้งหมด" Height="30px" Width="100%" cssClass= "btn-manage-products"/>
                        </div>
                        </div>
                        </div>
</asp:Content>

