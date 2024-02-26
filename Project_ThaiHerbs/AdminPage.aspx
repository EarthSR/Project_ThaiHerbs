<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct"
                            <p><h2>แอดมิน</h2></p>
                            <br />
                           <p><asp:Button ID="ButtonAdd" runat="server" Text="เพิ่มสินค้า" Height="30px" Width="100%" cssClass= "btn-manage-products"/ OnClientClick= "ButtonAdd"></p>
                            <p><asp:Button ID="ButtonEdit" runat="server" Text="แก้ไขข้อมูลสินค้า" Height="30px" Width="100%" cssClass= "btn-manage-products" /></p>
                           <p> <asp:Button ID="ButtonDelete" runat="server" Text="ลบสินค้า" Height="30px" Width="100%" cssClass= "btn-manage-products"/></p>
                        </div>
                        </div>
                        </div>

</asp:Content>

