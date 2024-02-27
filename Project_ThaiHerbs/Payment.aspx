<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "payment-container">
        <div class="payment-address">
            <asp:Label ID="lbltop" runat="server" ></asp:Label>
            <a><asp:LinkButton ID="lbl1" runat="server" Text="เปลี่ยน" OnClick="lbl1_Click1"/>
            <asp:TextBox ID="txtaddress" runat="server" Height="46px" TextMode="MultiLine" 
                Visible="False"></asp:TextBox>
            <asp:Button ID="btnupdate" runat="server" Text="ยืนยันเปลี่ยนที่อยู่" 
                OnClick="btnupdate_Click" Visible="False" />
            <asp:Button ID="btncancel" runat="server" Text="ยกเลิก" 
                OnClick="btncancel_Click" Visible="False" />
            </a>
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



                        <asp:Label ID="lblshow" runat="server"></asp:Label>


                    </div>
                        

                    <div class="payment-howto">
                        <p><a>ช่องทางชำระเงิน</a></p>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="designdrop" Width="174px" onchange="showImage();playSound()">
                            <asp:ListItem>เลือกช่องทางชำระเงิน</asp:ListItem>
                            <asp:ListItem>QR payment</asp:ListItem>
                            <asp:ListItem>บิด</asp:ListItem>
                        </asp:DropDownList>



                        <audio id="audioPlayer" controls style="display: none;">
                        <source src="Mp3/มงอยากโดยกสดากใชไหม.mp4.mp3" type="audio/mpeg">
                        </audio>


                        <div id="qrImage" style="display: none;">
                            <p><a>วิธีการชำระเงิน</a> โปรดแนบสลิปก่อนทำการกดสั่งซื้อ</p>
                            <img src= "../Image/QR.jpg" class ="qrcode">
                            <asp:Image ID="uploadedImage" runat="server" CssClass="qrcode" />
                              <div>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />
                                </div>
                        </div>
                         </div>
                      </div>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblt" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <br />
                        <div class = "ButtonPayment1">
                        <asp:Button ID="ButtonPayment" runat="server" Text="ยืนยันการสั่งซื้อสินค้า" 
                                CssClass="ButtonPayment" Height="55px" OnClientClick="playSound()" 
                                OnClick="ButtonPayment_Click" Visible="False" />
                            </div>
            </div>
            







                <script>
                    function showImage() {
                        var ddl = document.getElementById('<%= DropDownList1.ClientID %>');
                        var selectedOption = ddl.options[ddl.selectedIndex].text;
                        var qrImageDiv = document.getElementById('qrImage');

                        if (selectedOption === 'QR payment') {
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

