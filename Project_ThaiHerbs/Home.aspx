<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                    <div class="imgHome">
                            <img id="Image1" src="/ImgHerb/ขมิ้นชัน.jpg" class="logo1" onclick="nextImage()" />
                        </div>
                <asp:Label ID="lblshow" runat="server" Text=""></asp:Label>


        <script>
            var images = [
                "/ImgHerb/กัญชา.jpg",
                "/ImgHerb/กระวาน.jpg",
                "/ImgHerb/กระเจี๊ยบแดง.jpg",
                "/ImgHerb/กระชายดำ.jpg",
                "/ImgHerb/กะเพรา.jpg",
                "/ImgHerb/กานพลู.jpg",
                "/ImgHerb/เห็ดเทศ.jpg"
            ];

            var currentIndex = -1;

            function nextImage() {
                var img = document.getElementById('Image1');

                img.classList.add('slideOutLeft');

                setTimeout(function () {
                    var randomIndex;
                    do {
                        randomIndex = Math.floor(Math.random() * images.length);
                    } while (randomIndex === currentIndex);

                    currentIndex = randomIndex;

                    img.src = images[currentIndex];
                    img.classList.remove('slideOutLeft');
                    img.classList.add('slideInRight');
                }, 250);
            }
                        </script>
</asp:Content>

