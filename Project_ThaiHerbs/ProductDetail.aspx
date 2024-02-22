﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Productdetail.js"></script>
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="detail-container">

           <asp:PlaceHolder ID="productContainer" runat="server"></asp:PlaceHolder>

        <div class="review">
            <h2>
                <asp:Label ID="Label3" runat="server" Text="คะแนนสินค้า" />
            </h2>
            <br />
            <form class="star-rating">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/ImgHerb/กระเจี๊ยบแดง.jpg" CssClass="review-img" />

                <label class="radio-label" for="star1" title="1 star">1 star</label>
                <asp:RadioButton ID="star1" runat="server" CssClass="radio-input" GroupName="star-input"
                    Text="1 stars" value="1" />

                <label class="radio-label" for="star2" title="2 stars">2 stars</label>
                <asp:RadioButton ID="star2" runat="server" CssClass="radio-input" GroupName="star-input"
                    Text="2 stars" value="2" />

                <label class="radio-label" for="star3" title="3 stars">3 stars</label>
                <asp:RadioButton ID="star3" runat="server" CssClass="radio-input" GroupName="star-input"
                    Text="3 stars" value="3" />

                <label class="radio-label" for="star4" title="4 stars">4 stars</label>
                <asp:RadioButton ID="star4" runat="server" CssClass="radio-input" GroupName="star-input"
                    Text="4 stars" value="4" />

                <label class="radio-label" for="star5" title="5 stars">5 stars</label>
                <asp:RadioButton ID="star5" runat="server" CssClass="radio-input" GroupName="star-input"
                    Text="5 stars" value="5" />
            </form>
            <div class="txtreview">
                <p>
                    <asp:Label ID="Label5" runat="server" Text="Bob01 : " />

                    <a>สินค้าดีมากครับบบบ</a>
                </p>
            </div>
            <p class="align"></p>
        </div>
    </div>

</asp:Content>
