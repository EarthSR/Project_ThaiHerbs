<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="QRCode.aspx.cs" Inherits="QRCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "payment-container">
            <div class = "payment-boxdetail0">

                <img src= "ImgHerb/ดอกสำมะงา.jpg" class ="qrcode">
                <div class = "qrcode">
                        <a>รบกวนแนบใบเสร็จชำระเงินด้วยนะครับ</a>
                    </div>
                  <div>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />
                    </div>

            </div>
         </div>





     <script>



     </script>

</asp:Content>

