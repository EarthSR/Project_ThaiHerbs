﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Tracking.aspx.cs" Inherits="Tracking" %>

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
                            <p>ชื่อขนส่ง</p>
                        </div>
                        <div class="tracking-column">
                            <p>หมายเลขพัสดุ</p>
                        </div>
                        <div class="tracking-column">
                            <p>สถานะการจัดส่ง</p>
                        </div>
                    </div>
                </div>







            <div class = "tracking">  
                <div class="content">
                <img id="mainImage" src="ImgHerb/ดอกสำมะงา.jpg" class="imgtracking" />
                <p>ดอกไม้ชนิดหนึ่ง</p>
                </div>
            <div class="content">
                <p>ดอกไม้ชนิดหนึ่ง</p>
                </div>

                 <div class="content">
                     <p>ดอกไม้ชนิดหนึ่ง</p>
                     </div>
                    <div class="content">
                     <p>ดอกไม้ชนิดหนึ่ง</p>
                     </div>
            </div>



        <div class = "tracking">  
    <div class="content">
    <img id="mainImage" src="ImgHerb/ดอกสำมะงา.jpg" class="imgtracking" />
    <p>ดอกไม้ชนิดหนึ่ง</p>
    </div>
<div class="content">
    <p>ดอกไม้ชนิดหนึ่ง</p>
    </div>

     <div class="content">
         <p>ดอกไม้ชนิดหนึ่ง</p>
         </div>
        <div class="content">
         <p>ดอกไม้ชนิดหนึ่ง</p>
         </div>
</div>

               
        </div>



</asp:Content>

