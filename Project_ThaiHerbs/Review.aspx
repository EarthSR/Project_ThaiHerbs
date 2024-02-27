﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="menu-user-product">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="แก้ไขข้อมูล" 
                        CssClass="category-link" PostBackUrl="~/ProfileUser.aspx" />
                    <asp:LinkButton ID="LinkButtonTrack" runat="server" Text="ติดตามการจัดส่ง" 
                        CssClass="category-link" 
                        PostBackUrl="~/Tracking.aspx" />
                    <asp:LinkButton ID="LinkButtonRate" runat="server" Text="ให้คะแนนสินค้า" 
                        CssClass="category-link" PostBackUrl="~/Review.aspx" />
                    <asp:LinkButton ID="LinkButtonHome" runat="server" Text="กลับหน้าหลัก" 
                        CssClass="category-link"
                        style="width: 192px" PostBackUrl="~/Home.aspx" />
        </div> 
    <div class="user-product">

              <div class="detail-tracking">
                    <div class="tracking-header">
                        <div class="tracking-column">
                            <p>รายการสั่งซื้อ</p>
                        </div>
                        <div class="tracking-column">
                            <p>ประเมินคุณภาพ</p>
                        </div>
                        <div class="tracking-column">
                            <p>รีวิว</p>
                        </div>
                    </div>
                </div>


                <div class="tracking">  
                    <div class="content">
                        <img id="mainImage1" src="ImgHerb/ดอกสำมะงา.jpg" class="imgtracking" />
                        <p>ดอกไม้ชนิดหนึ่ง</p>
                    </div>
                    <div class="content">
                        <form action="">
                            <input type="radio" id="star5_1" name="rating1" value="5">
                            <label for="star5_1">5</label>&nbsp;&nbsp;&nbsp;
                            <input type="radio" id="star4_1" name="rating1" value="4">
                            <label for="star4_1">4</label>&nbsp;&nbsp;&nbsp;
                            <input type="radio" id="star3_1" name="rating1" value="3">
                            <label for="star3_1">3</label>&nbsp;&nbsp;&nbsp;
                            <input type="radio" id="star2_1" name="rating1" value="2">
                            <label for="star2_1">2</label>&nbsp;&nbsp;&nbsp;
                            <input type="radio" id="star1_1" name="rating1" value="1">
                            <label for="star1_1">1</label>&nbsp;&nbsp;&nbsp;
                        </form>
                    </div>
                    <div class="content">
                        <textarea id="review1" name="review1" rows="4" placeholder="เขียนรีวิวของคุณ"></textarea>
                    </div>
                </div>  






                    </div>
                    <div>
                    <asp:Button ID="ButtonSignIn" runat="server"  Text="ส่งรีวิว" CssClass = "editinfo2" Height="57px" Width="131px"/>
                    </div>
</asp:Content>

