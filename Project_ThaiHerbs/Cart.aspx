<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSearch.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class ="cart-container">
    <div class = "cart-top ">
        <div class ="chkbox">
        <label class="material-checkbox">
        <input type="checkbox" class="auto-style1">
        <span class="checkmark"></span>
        เลือกสินค้าทั้งหมด
      </label>
            </div>
     </div> 
        
        <asp:Label ID="lblshow" runat="server" ></asp:Label>
       
        <div class ="btn">
            <asp:Label ID="Label3" runat="server" Text="ราคารวม :" />
                <asp:Label ID="Label2" runat="server" Text="(000)  ฿" />&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button runat="server" Text="สั่งซื้อ" CssClass="btncart" />
        </div>
    </div>
</asp:Content>

