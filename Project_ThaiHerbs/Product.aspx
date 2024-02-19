<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="box">
    <div class="product-card">
        <div class="product-image">
            <img src=""/>
        </div>
        <div class="product-details">
            <h2>Product Name</h2>
            <p>product_Detail</p>
            <div class="price">$199</div>
        </div>
        <div class="buttons">
            <asp:Button runat="server" Text="Add to Cart" CssClass="btn-add-to-cart" />
        </div>
    </div>
</asp:Content>

