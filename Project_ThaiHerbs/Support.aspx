<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="~/CSS/StyleSheet.css"]/>
    <style type="text/css">
        .auto-style1 {
            width: 92%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <div id = "support">
    <div class = "imgContect">
    <asp:Image ID="Line" runat="server" ImageUrl="~/img/line.png" Height="150px" Width="150px" />
    <br />
    <br />
    <asp:Label ID="lblline" runat="server" Text="Line ID : ######" />
    </div>

    <div class = "imgContect">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/facebook (1).png" Height="150px" Width="150px" />
    <br />
    <br />
    <asp:Label ID="lblfacebook" runat="server" Text="Facebook : ######" />
    </div>
    <br />
    <br />
    <div class = "imgContect2">
    <asp:Image ID="Phone" runat="server" ImageUrl="~/img/telephone.png" Height="150px" Width="150px" />
    <br />
    <br />
    <asp:Label ID="lblphone" runat="server" Text="Phone : #####" />
    </div>
</div>
</asp:Content>

