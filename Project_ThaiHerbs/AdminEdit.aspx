<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="AdminEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "addminproduct-container"> 
    <div class = "manage-products">
        <div class = "txt-addminproduct">
         <h1><asp:Label ID="lblresult" runat="server" Text = "จัดการแก้ไขสินค้า" CssClass = "manage-products-title"></asp:Label></h1>
            <br />
        </div>
        <div>
        <p><h3><asp:Label ID="Label1" runat="server" Text = "ชื่อสินค้า"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
        </div>

        <div>
        <p><h3><asp:Label ID="Label2" runat="server" Text = "ราคา"></asp:Label></h3>
        <asp:TextBox ID="TextBox2" runat="server" Height="38px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
        <h3><asp:Label ID="Label3" runat="server" Text = "จำนวน"></asp:Label></h3>
        <asp:TextBox ID="TextBox3" runat="server" Height="38px" Width="100%" CssClass= "manage-products-box"></asp:TextBox>
        </div>

        <div>
        <p><h3><asp:Label ID="Label4" runat="server" Text = "รายละเอียด"></asp:Label></h3>
        <asp:TextBox ID="TextBox4" runat="server" Height="100px" Width="100%" TextMode="MultiLine" CssClass= "manage-products-box"></asp:TextBox>
        </p>
        </div>

        <div>
         <p><h3><asp:Label ID="Label5" runat="server" Text = "รูปภาพ"></asp:Label></h3>
         <p><img src="../ImgHerb/กัญชา.jpg" width ="100px" height ="100px"/></p>
         <asp:FileUpload ID="FileUpload1" runat="server" />
         <asp:Button ID="ButtonUpload" runat="server" Text="เพิ่มรูปภาพ"/>
        
        </div>
        <div>
            <br />
            <br />
            <br />
         <asp:Button ID="ButtonSignIn" runat="server" Text="แก้ไขข้อมูลสืนค้า" Height="30px" Width="100%" cssClass= "btn-manage-products"/>
        </div>
    </div>
</div>
</asp:Content>

