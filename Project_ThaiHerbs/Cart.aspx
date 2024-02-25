<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSearch.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="cart-container">
        <div class="cart-top">
            <asp:Button runat="server" Text="Delete All Product in cart" CssClass="btnDeleteItem" OnClick="Unnamed1_Click"  />
            <asp:Label ID="lblresult" runat="server"></asp:Label>
        </div> 
        
        <asp:Label ID="lblshow" runat="server"></asp:Label>
        <br />
        <br />
        <div class="cart-container">
       <div class="btn" >
            <asp:Label ID="lbltotal" runat="server" Text="ราคารวม : " />
           <br />
           <asp:Label ID="lblbamount" runat="server" Text="จำนวนทั้งหมด : " />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" Text="สั่งซื้อ" CssClass="btncart" OnClick="Unnamed2_Click" />
            
       </div>
   
            </div>
     </div>  
          
    </div>
</asp:Content>

