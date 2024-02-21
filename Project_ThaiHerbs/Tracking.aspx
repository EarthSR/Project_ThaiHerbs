<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Tracking.aspx.cs" Inherits="Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class = "tracking-container">
        <br />
        <h2  class = "texttracking">รายการจัดส่งสินค้า</h2>
        <div class = "tracking-box">

            <asp:Image ID="track" runat="server" ImageUrl="~/ImgHerb/กัญชา.jpg" CssClass="imgtracking" />
            <asp:Label ID ="texttrack" runat = "server" Text = ""></asp:Label>
        </div>
         
       

    </div>
</asp:Content>

