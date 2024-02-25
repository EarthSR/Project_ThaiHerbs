<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Tracking.aspx.cs" Inherits="Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="user-product">
        <div class="menu-user-product">
            <asp:HyperLink ID="HyperLinkEdit" runat="server" Text="แก้ไขข้อมูล" NavigateUrl="#" CssClass="category-link" />
            <asp:HyperLink ID="HyperLinkTrack" runat="server" Text="ติดตามการจัดส่ง" NavigateUrl="#" CssClass="category-link" />
            <asp:HyperLink ID="HyperLinkRate" runat="server" Text="ให้คะแนนสินค้า" NavigateUrl="#" CssClass="category-link" />
            <asp:HyperLink ID="HyperLinkHome" runat="server" Text="กลับหน้าหลัก" NavigateUrl="~/Login.aspx" CssClass="category-link" />
        </div>
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
                            <p>รายละเอียดจัดส่ง</p>
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

