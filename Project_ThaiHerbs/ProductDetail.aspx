<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageHome.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Productdetail.js"></script>
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class = "detail-container">
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
	            <input type="button" value="-" class="minus" style="width: 40px; height: 26px;">
                <input type="number" step="1" min="1" max="" name="quantity" value="1" title="Qty" class="input-text qty text" size="4" pattern="" inputmode="" style="width: 53px; height: 24px;">
                <input type="button" value="+" class="plus" style="width: 40px; height: 26px;">
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
                                  <asp:Image ID="Image1" runat="server" ImageUrl="~/ImgHerb/กระเจี๊ยบแดง.jpg" CssClass="review-img"/>
                                  <input class="radio-input" type="radio" id="star5" name="star-input" value="5" />
                                  <label class="radio-label" class for="star5" title="5 stars">5 stars</label>
                                    
                                  <input class="radio-input" type="radio" id="star4" name="star-input" value="4" />
                                  <label class="radio-label" for="star4" title="4 stars">4 stars</label>

                                  <input class="radio-input" type="radio" id="star3" name="star-input" value="3" />
                                  <label class="radio-label" for="star3" title="3 stars">3 stars</label>

                                  <input class="radio-input" type="radio" id="star2" name="star-input" value="2" />
                                  <label class="radio-label" for="star2" title="2 stars">2 stars</label>

                                  <input class="radio-input" type="radio" id="star1" name="star-input" value="1" />
                                  <label class="radio-label" for="star1" title="1 star">1 star</label>
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