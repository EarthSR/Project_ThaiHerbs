<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="menu-user-product">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="แก้ไขข้อมูล" 
                        CssClass="category-link" PostBackUrl="~/ProfileUser.aspx" />
                    <asp:LinkButton ID="LinkButtonTrack" runat="server" Text="ติดตามการจัดส่ง" 
                        CssClass="category-link" 
                        PostBackUrl="~/Tracking.aspx" />
                    <asp:LinkButton ID="LinkButtonRate" runat="server" Text="ออเดอร์ทั้งหมด" 
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
                                            <p>จำนวน</p>
                                        </div>
                                        <div class="tracking-column">
                                            <p>ราคา</p>
                                        </div>
                                        <div class="tracking-column">
                                            <p>วันที่สั่งซื้อ</p>
                                        </div>
                                    </div>
                                </div>


                                <div class="tracking">  
                                    <div class="content">
                                        <img id="mainImage1" src="ImgHerb/ดอกสำมะงา.jpg" class="imgtracking" />
                                        <p>ดอกสำมันงา</p>
                                    </div>
                                    <div class="content">
                                        <p>10</p>
                                    </div>
                                    <div class="content">
                                        <p>300</p>
                                    </div>
                                    <div class="content">
                                        <p>10/12/2024</p>
                                    </div>
                                </div>  
                                    </div>
</asp:Content>

