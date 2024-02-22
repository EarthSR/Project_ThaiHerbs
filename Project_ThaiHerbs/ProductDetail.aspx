<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Productdetail.js"></script>
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "detail-container">





        <script type="text/javascript">
            function decreaseQuantity() {
                var quantityInput = document.getElementById('<%= quantityInput.ClientID %>');
        if (parseInt(quantityInput.value) > 1) {
            quantityInput.value = parseInt(quantityInput.value) - 1;
        }
        return false; // เพื่อป้องกันการโพสต์กลับเซิร์ฟเวอร์
    }

    function increaseQuantity() {
        var quantityInput = document.getElementById('<%= quantityInput.ClientID %>');
                if (parseInt(quantityInput.value) < 100) {
                    quantityInput.value = parseInt(quantityInput.value) + 1;
                }
                return false; // เพื่อป้องกันการโพสต์กลับเซิร์ฟเวอร์
            }
        </script>






            <div class="detail-image">
                <asp:Image ID="logo" runat="server" ImageUrl="~/ImgHerb/กระเจี๊ยบแดง.jpg" CssClass="detail-img"/>
           </div>
            <div class="detail-image">
                <h2><asp:Label ID="Label" runat="server" Text="กระเจี๊ยบแดง" /></h2>
                <h2><asp:Label ID="lblprice" runat="server" Text="100000000000000000 บาท" /></h2>
                <a><asp:Label ID="Label1" runat="server" Text="สรรพคุณ : ประโยชน์และสรรพคุณกระเจี๊ยบแดง แก้อาการขัดเบา แก้เสมหะ ช่วยขับน้ำดี ช่วยลดไข้ แก้ร้อนใน แก้ไอ ขับนิ่วในไต นิ่วในกระเพาะปัสสาวะ แก้อ่อนเพลีย บำรุงธาตุ บำรุงกำลัง บำรุงโลหิต แก้กระหายน้ำ รักษาไตพิการ ขับเมือกมันให้ลงสู่รูทวารหนัก ละลายไขมันในเลือด เป็นยาระบาย แก้ไตพิการ ลดอาการบวม แก้เลือดออกตามไรฟัน เป็นยาฆ่าพยาธิตัวจี๊ด รักษาแผลอักเสบ แผลติดเชื้อ แก้โรคเบาหวาน ช่วยรักษาแผลในกระเพาะอาหาร ช่วยป้องกันโรคต่อมลูกหมากโต ช่วยฆ่าเชื้อแบคทีเรีย ช่วยป้องกันการเกิดโรคมะเร็ง" /></a>
                <br />
                <br />
                <div class="quantity buttons_added">
                    <a><asp:Label ID="Label2" runat="server" Text="จำนวน : " /></a>
	            <asp:Button ID="minusButton" runat="server" Text="-" CssClass="minus" OnClientClick="return decreaseQuantity();" style="width: 40px; height: 26px;" />
                <asp:TextBox ID="quantityInput" runat="server" Text="1" CssClass="input-text qty text" Width="53px" Height="24px" pattern="\d*" inputmode="numeric" />
                <asp:Button ID="plusButton" runat="server" Text="+" CssClass="plus" OnClientClick="return increaseQuantity();" style="width: 40px; height: 26px;" />
                     </div>
                <br />
                <br />
                <div class = "bottons">
                <asp:Button runat="server" Text="Add to Cart" CssClass="btn-adddetail" />
                <asp:Button runat="server" Text="Back to shop" CssClass="btn-adddetail" />
                </div>
            </div>
            <div class = "review">
                <h2><asp:Label ID="Label3" runat="server" Text="คะแนนสินค้า" /></h2>     
                <br />
                                <form class="star-rating">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ImgHerb/กระเจี๊ยบแดง.jpg" CssClass="review-img" />
    
                                    <label class="radio-label" for="star1" title="1 star">1 star</label>
                                    <asp:RadioButton ID="star1" runat="server" CssClass="radio-input" GroupName="star-input" Text="1 stars" value="1" />
    
                                    <label class="radio-label" for="star2" title="2 stars">2 stars</label>
                                    <asp:RadioButton ID="star2" runat="server" CssClass="radio-input" GroupName="star-input" Text="2 stars" value="2" />
    
                                    <label class="radio-label" for="star3" title="3 stars">3 stars</label>
                                    <asp:RadioButton ID="star3" runat="server" CssClass="radio-input" GroupName="star-input" Text="3 stars" value="3" />
    
                                    <label class="radio-label" for="star4" title="4 stars">4 stars</label>
                                    <asp:RadioButton ID="star4" runat="server" CssClass="radio-input" GroupName="star-input" Text="4 stars" value="4" />
    
                                    <label class="radio-label" for="star5" title="5 stars">5 stars</label>
                                    <asp:RadioButton ID="star5" runat="server" CssClass="radio-input" GroupName="star-input" Text="5 stars" value="5" />
                                </form>
                            <div class = "txtreview">
                             <p><asp:Label ID="Label5" runat="server" Text="Bob01 : " />

                                 <a>สินค้าดีมากครับบบบ</a>








                             </p>
                            </div>
                            <p class = "align"></p> 
        </div>
        </div>

    </asp:Content>