<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct"
                            <p><h2>แอดมิน</h2></p>
                            <br />
                            <p> <asp:Button ID="ButtonAdd" runat="server" Text="เพิ่มสินค้า" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products"  
                                    PostBackUrl="~/Admin/AdminProduct.aspx"/></p>
                            <p><asp:Button ID="ButtonEdit" runat="server" Text="แก้ไขและลบข้อมูลสินค้า" 
                                    Height="30px" Width="100%" cssClass= "btn-manage-products" 
                                   PostBackUrl="~/Admin/AdminEditandDelete.aspx"/></p>
                            <p> <asp:Button ID="Button4" runat="server" Text="สินค้าในคลัง" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" 
                                    PostBackUrl="~/Admin/AdminProductAll.aspx" /></p>
                            <p> <asp:Button ID="Button1" runat="server" Text="ยืนยันออเดอร์" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" /></p>
                            <p> <asp:Button ID="Button3" runat="server" Text="ที่ต้องจัดส่ง" Height="30px" Width="100%" cssClass= "btn-manage-products" /></p>
                            <p> <asp:Button ID="Button2" runat="server" Text="ออเดอร์ที่สำเร็จ" Height="30px" Width="100%" cssClass= "btn-manage-products"/></p>
                            
                        </div>
                        </div>
                        </div>

</asp:Content>

