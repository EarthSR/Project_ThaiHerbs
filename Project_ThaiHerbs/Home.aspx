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
                "/ImgHerb/lime.jpg",
                "/ImgHerb/กระเจี๊ยบแดง.jpg",
                "/ImgHerb/กระชายดำ.jpg",
                "/ImgHerb/กระวาน.jpg",
                "/ImgHerb/กะเพรา.jpg",
                "/ImgHerb/กัญชา.jpg",
                "/ImgHerb/กานพลู.jpg",
                "/ImgHerb/ขมิ้นชัน.jpg",
                "/ImgHerb/ดอกสำมะงา.jpg",
                "/ImgHerb/ทองพันชั่ง.jpg",
                "/ImgHerb/บอระเพ็ด.jpg",
                "/ImgHerb/บัวบก.jpg",
                "/ImgHerb/ฟ้าทะลายโจร.jpg",
                "/ImgHerb/มะกรูด.jpg",
                "/ImgHerb/มะขามป้อม.jpg",
                "/ImgHerb/มะรุม.jpg",
                "/ImgHerb/มะแว้ง.jpg",
                "/ImgHerb/ย่านาง.jpg",
                "/ImgHerb/รางจืด.jpg",
                "/ImgHerb/ว่านชักมดลูก.jpg",
                "/ImgHerb/ว่านหางจระเข้.jpg",
                "/ImgHerb/เสลดพังพอน.jpg",
                "/ImgHerb/หญ้าหนวดแมว.jpg",
                "/ImgHerb/เห็ดเทศ.jpg",
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
            setInterval(nextImage, 4000);
            </script>
</asp:Content>

