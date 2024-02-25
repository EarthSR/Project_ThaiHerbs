<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "payment-container">
        <div class="payment-address">
            <p>📍 ที่อยู่ในการจัดส่ง</p>
            <p><a>bobby01 : 0922222222</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a>ที่อยู่</a>
            <a><asp:LinkButton ID="lbl1" runat="server" Text="เปลี่ยน"/></a>
            </p>
        </div>

        <div class = "payment-boxdetail0">
                    <div class= "payment-boxdetail">
                       <div class="payment-boxdetail2">
                           <p>รายการสั่งซื้อ</p>
                       </div>
                        <div class="payment-boxdetail2">
                            <p></p>
                        </div>
                        <div class="payment-boxdetail2">
                            <p></p>
                        </div>
                       <div class="payment-boxdetail2">
                           <p>ราคา</p>
                       </div>
                       <div class="payment-boxdetail2">
                           <p>จำนวน</p>
                       </div>
                      </div>
                        

            <div class= "payment-price">
                     <asp:Label ID="lblshow" runat="server" ></asp:Label>
                <br />
            </div>
            </div>




                    <div class="payment-howto">
                <p><a>วิธีการชำระเงิน</a></p>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="designdrop" Width="174px" onchange="showImage();playSound()">
                    <asp:ListItem>เก็บเงินปลายทาง</asp:ListItem>
                    <asp:ListItem>QR Code</asp:ListItem>
                    <asp:ListItem>บิด</asp:ListItem>
                </asp:DropDownList>

                <div id="qrImage" style="display:none;">
                    <br />
                    <a>Qr Code จะแสดงหลังยืนยันคำสั่งซื้อ</a>
                </div>



                        <audio id="audioPlayer" controls style="display: none;">
                        <source src="Mp3/มงอยากโดยกสดากใชไหม.mp4.mp3" type="audio/mpeg">
                        </audio>



                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class = "ButtonPayment1">
                        <asp:Button ID="ButtonPayment" runat="server" Text="ยืนยันการสั่งซื้อสินค้า" CssClass="ButtonPayment" Height="55px" OnClientClick="playSound()" />
                            </div>
            </div>
            







                <script>
                    function showImage() {
                        var ddl = document.getElementById('<%= DropDownList1.ClientID %>');
                        var selectedOption = ddl.options[ddl.selectedIndex].text;
                        var qrImageDiv = document.getElementById('qrImage');
                        var qrImage = document.getElementById('qrCodeImage');

                        if (selectedOption === 'QR Code') {
                            qrImageDiv.style.display = 'block';
                        } else {
                            qrImageDiv.style.display = 'none';
                        }
                    }

                            function playSound() {
                                var selectedOption = document.getElementById("<%= DropDownList1.ClientID %>").value;
                               var audioPlayer = document.getElementById("audioPlayer");

                               if (selectedOption === "บิด") {
                                   audioPlayer.play();
                               } else {
                                   audioPlayer.pause();
                                   audioPlayer.currentTime = 0; // เล่นตั้งแต่จุดเริ่มต้นหลังจากหยุด
                               }
                           }



                </script>


</asp:Content>

