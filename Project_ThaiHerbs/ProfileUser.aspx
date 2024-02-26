﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="ProfileUser.aspx.cs" Inherits="ProfileUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="user-product">
            <div class="menu-user-product">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="แก้ไขข้อมูล" CssClass="category-link" />
                    <asp:LinkButton ID="LinkButtonTrack" runat="server" Text="ติดตามการจัดส่ง" CssClass="category-link" OnClick="LinkButtonTrack_Click" />
                    <asp:LinkButton ID="LinkButtonRate" runat="server" Text="ให้คะแนนสินค้า" CssClass="category-link" />
                    <asp:LinkButton ID="LinkButtonHome" runat="server" Text="กลับหน้าหลัก" 
                        CssClass="category-link" OnClick="LinkButtonHome_Click"/>
                </div>
            <div class="detail-profile">
                    <a href="#" id="ImageLink" runat="server">
                        <input type="file" id="imageInput" accept="image/*" style="display: none;" onchange="previewImage(event)">
                        <img id="mainImage" src="ImgHerb/ดอกสำมะงา.jpg" class="imgprofile" onclick="document.getElementById('imageInput').click();" />
                    </a>
                <div class="detail-profile1">
                    <p><a>Username</a></p>
                    <p><a>Password</a></p>
                    <p><a>Firstname</a></p>
                    <p><a>Lastname</a></p>
                    <p><a>Email</a></p>
                    <p><a>Phone</a></p>
                    <p><a>Gender</a></p>
                     <p><a>NewGender</a></p>
                    <p><a>Address</a></p>
                </div>
                <div class="detail-profile2">
                        <p><asp:TextBox ID="username" runat="server" Text="" ReadOnly="True" /></p>
                        <p><asp:TextBox ID="password" runat="server" Text="" /></p>
                        <p><asp:TextBox ID="firstname" runat="server" Text="" /></p>
                        <p><asp:TextBox ID="Lastname" runat="server" Text="" /></p>
                        <p><asp:TextBox ID="email" runat="server" Text="" /></p>
                        <p><asp:TextBox ID="phone" runat="server" Text="" /></p>
                    <p>
                        <asp:Label ID="gender" runat="server"></asp:Label></p>
                    <p>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="designdrop" Width="174px">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>

                    </p>
                            <div>
                    <p>
                        <asp:TextBox ID="address" runat="server" TextMode="MultiLine" Height="61px"></asp:TextBox>
                    </p>

               

        </div>
                        <div class="auto-style2">
                    <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
     <asp:Button ID="ButtonSignIn" runat="server" CssClass="editinfo" Text="บันทึกข้อมูล" Height="43px" 
                            Width="147px" OnClick="ButtonSignIn_Click"  />
                        </div>

</asp:Content>

