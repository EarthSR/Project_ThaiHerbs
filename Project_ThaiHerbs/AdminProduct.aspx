﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminProduct.aspx.cs" Inherits="AdminProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct">
                         <h1><asp:Label ID="lblresult" runat="server" Text = "จัดการเพิ่มสินค้า" CssClass = "manage-products-title"></asp:Label></h1>
                            <br />
                        </div>

                        <div>
                        <p><h3><asp:Label ID="Label1" runat="server" Text = "ชื่อสินค้า"></asp:Label></h3>
                        <asp:TextBox ID="txtname" runat="server" Height="34px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        </div>

                        <div>
                        <p><h3><asp:Label ID="Label2" runat="server" Text = "ราคา"></asp:Label></h3>
                        <asp:TextBox ID="txtprice" runat="server" Height="38px" Width="100%" CssClass= "manage-products-box"></asp:TextBox></p>
                        <h3><asp:Label ID="Label3" runat="server" Text = "จำนวน"></asp:Label></h3>
                        <asp:TextBox ID="txtamount" runat="server" Height="38px" Width="100%" CssClass= "manage-products-box"></asp:TextBox>
                        </div>

                        <div>
                        <p><h3><asp:Label ID="Label4" runat="server" Text = "รายละเอียด"></asp:Label></h3>
                        <asp:TextBox ID="txtdetail" runat="server" Height="100px" Width="100%" TextMode="MultiLine" CssClass= "manage-products-box"></asp:TextBox>
                        </p>
                            </div>

                        <div>
                         <p><h3><asp:Label ID="Label5" runat="server" Text = "เพิ่มรูปภาพ"></asp:Label></h3>
                         <p><img src="../ImgHerb/กัญชา.jpg" width ="100px" height ="100px"/></p>
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                         <asp:Button ID="ButtonUpload" runat="server" Text="เพิ่มรูปภาพ"/>
                        </div>
                        <div>
                            <br />
                            <br />
                            <br />
                            <p><asp:Button ID="ButtonSignIn" runat="server" Text="เพิ่มสินค้า" Height="30px" Width="100%" cssClass= "btn-manage-products"/></p>
                        </div>
                    </div>
                </div>

</asp:Content>

