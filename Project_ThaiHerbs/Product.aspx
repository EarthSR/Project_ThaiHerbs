<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="product-card">
        <div class="product-image">
            <img src=""/>
        </div>
        <div class="product-details">
            <h2>Product Name</h2>
            <p>...</p>
            <div class="price">$199</div>
        </div>
        <div class="buttons">
            <asp:Button runat="server" Text="Add to Cart" CssClass="btn-add-to-cart" />
        </div>
        <div class = "img">
<asp:Image ID="Image1" runat="server" ImageUrl="~/ImgHerb/ขมิ้นชัน.jpg" CssClass="logo" width ="100%"/>
</div>
    </div>

</asp:Content>

