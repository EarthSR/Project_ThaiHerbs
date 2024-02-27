<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct"
                            <p><h2>แอดมิน</h2></p>
                            <br />
                            <p> <asp:Button ID="ButtonAdd" runat="server" Text="เพิ่มสินค้า" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonAdd_Click" 
                                    PostBackUrl="~/Admin/AdminProduct.aspx"/></p>
                            <p><asp:Button ID="ButtonEdit" runat="server" Text="แก้ไขข้อมูลสินค้า" 
                                    Height="30px" Width="100%" cssClass= "btn-manage-products" 
                                    OnClick= "ButtonEdit_Click" PostBackUrl="~/Admin/AdminEdit.aspx"/></p>
                            <p> <asp:Button ID="ButtonDelete" runat="server" Text="ลบสินค้า" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonDelete_Click" 
                                    PostBackUrl="~/Admin/AdminDelete.aspx"/></p>
                            <p> <asp:Button ID="Button4" runat="server" Text="สินค้าในคลัง" Height="30px" Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonDelete_Click"/></p>
                            <p> <asp:Button ID="Button1" runat="server" Text="ยืนยันออเดอร์" Height="30px" Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonDelete_Click"/></p>
                            <p> <asp:Button ID="Button3" runat="server" Text="ที่ต้องจัดส่ง" Height="30px" Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonDelivery_Click"/></p>
                            <p> <asp:Button ID="Button2" runat="server" Text="ออเดอร์ที่สำเร็จ" Height="30px" Width="100%" cssClass= "btn-manage-products" OnClick= "ButtonDelete_Click"/></p>
                            
                        </div>
                        </div>
                        </div>

</asp:Content>

