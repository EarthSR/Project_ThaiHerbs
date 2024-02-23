<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="supportpage">
    <div class="imgContect">
        <asp:HyperLink ID="LineLink" runat="server" NavigateUrl="https://line.me/th/">
            <asp:Image ID="Line" runat="server" ImageUrl="~/img/line.png" Height="150px" Width="150px" />
        </asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lblline" runat="server" Text="Line ID : ######" />
    </div>

    <div class="imgContect">
        <asp:HyperLink ID="FacebookLink" runat="server" NavigateUrl="https://www.facebook.com/">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/facebook (1).png" Height="150px" Width="150px" />
        </asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lblfacebook" runat="server" Text="Facebook : ######" />
    </div>

    <br />
    <br />

    <br />
    <br />

    <div class="imgContect2">
        <asp:HyperLink ID="PhoneLink" runat="server" NavigateUrl="https://vk.com/">
            <asp:Image ID="Phone" runat="server" ImageUrl="~/img/telephone.png" Height="150px" Width="150px" />
        </asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lblphone" runat="server" Text="Phone : #####" />
        <br />
        <br />
        <br />
    </div>
</div>

</div>
</asp:Content>

