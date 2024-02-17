<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class = "imgHome">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/ImgHerb/ขมิ้นชัน.jpg" CssClass="logo" Width = "100%" Height ="100%"/>
    </div>
    <div class = "txtonimg">
        <a>ขมิ้นชัน</a>
    </div>
    <a class = "txtonimg2">สมุนไพรคู่ครัวที่คนไทยรู้จักกันดี </a>
    <a class = "txtonimg3 "> อุดมไปด้วยวิตามินและแร่ธาตุหลายชนิด</a>        
    <a class = "txtonimg4">นิยมนำมาทำอาหารเนื่องจากมีสีสันสวยงามและให้กลิ่นหอม</a>
    <asp:Button ID="ButtonSignIn" runat="server" Text="ดูเพิ่มเติม" CssClass="designbox"  Height="36px" Width="208px" />


</asp:Content>

