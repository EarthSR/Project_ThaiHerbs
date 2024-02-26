<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Productdetail.js"></script>
    <style type="text/css">
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="detail-container">
        <asp:Label ID="lblshow" runat="server" ></asp:Label>
        <br />
        <div>
        <asp:Button ID="minus" runat="server" Text="-" OnClick="minus_Click" />
        <asp:TextBox ID="txtamount" runat="server" Width="49px" style="text-align: center">1</asp:TextBox>
        <asp:Button ID="plus" runat="server" Text="+" OnClick="plus_Click" />
        </div>
        <br />
        <asp:Label ID="lble" runat="server"></asp:Label>
        <br />
        <br />
        <div class="bottons">
            <asp:Button ID="btnadd" runat="server" Text="Add to Cart" 
                CssClass="btn-adddetail" OnClick="btnadd_Click" />
        </div>
                <br />
                <br />

            </div>

        <div class="review">
            <h2>
                <asp:Label ID="Label3" runat="server" Text="คะแนนสินค้า" />
            </h2>
            <br />
           
            <p class="align">
                <asp:Label ID="lblcom" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>

</asp:Content>
