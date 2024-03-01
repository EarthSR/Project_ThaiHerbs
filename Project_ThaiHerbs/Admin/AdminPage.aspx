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
                            <p> <asp:Button ID="btnorder" runat="server" Text="ยืนยันออเดอร์" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" 
                                    PostBackUrl="~/Admin/AdminSellList.aspx" /></p>
                            <p> <asp:Button ID="btndelivery" runat="server" Text="ที่ต้องจัดส่ง" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" 
                                    PostBackUrl="~/Admin/AdminShipping.aspx" /></p>
                            <p> <asp:Button ID="btnupdate" runat="server" Text="อัพเดตจัดส่ง" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" 
                                    PostBackUrl="~/Admin/Adminupdateship.aspx" /></p>
                            <p> <asp:Button ID="btncom" runat="server" Text="ออเดอร์ที่สำเร็จ" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" 
                                    PostBackUrl="~/Admin/AdminCom.aspx"/></p>
                            
                        </div>
                        </div>
                        </div>

</asp:Content>

