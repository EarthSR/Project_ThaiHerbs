<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Productdetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "detail-container">
            <div class="detail-image">
                <asp:Image ID="logo" runat="server" ImageUrl="~/ImgHerb/กระเจี๊ยบแดง.jpg" CssClass="detail-img"/>
           </div>
            <div class="detail-image">
                <h2><asp:Label ID="Label" runat="server" Text="กระเจี๊ยบแดง" /></h2>
                <h2><asp:Label ID="lblprice" runat="server" Text="49 บาท" /></h2>
                <a><asp:Label ID="Label1" runat="server" Text="สรรพคุณ : ช่วยให้สดชื่นเวลาดื่ม" /></a>
                <br />
                <br />
                <div class="quantity buttons_added">
	            <input type="button" value="-" class="minus" style="width: 40px">
                <input type="number" step="1" min="1" max="" name="quantity" value="1" title="Qty" class="input-text qty text" size="4" pattern="" inputmode="" style="width: 202px">
                <input type="button" value="+" class="plus" style="width: 40px">
                 </div>
                <br />
                <br />
                <div class = "bottons">
                <asp:Button runat="server" Text="Add to Cart" CssClass="btn-adddetail" />
                <asp:Button runat="server" Text="Back to shop" CssClass="btn-adddetail" />
                </div>
            </div>
            


    </div>
    </asp:Content>