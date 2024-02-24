<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSearch.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="cart-container">
        <div class="cart-top">
            <asp:Button runat="server" Text="ลบรายการสินค้า" CssClass="btnDeleteItem" OnClick="Unnamed1_Click"  />
        </div> 
        
        <asp:Label ID="lblshow" runat="server"></asp:Label>

       <div class="btn">
            <asp:Label ID="Label3" runat="server" Text="ราคารวม :" />
            <div id="totalPrice">0.00</div>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" Text="สั่งซื้อ" CssClass="btncart" />
       </div>
    </div>

    <script type="text/javascript">
        function calculateTotal(inputId) {
            var inputElement = document.getElementById('quantityInput' + inputId);
            var quantity = inputElement.value;
            var priceElement = document.getElementById('price' + inputId);
            var price = parseFloat(priceElement.innerText); // ดึงราคาสินค้าออกมาและแปลงเป็นตัวเลข

            var totalElement = document.getElementById('totalPrice');
            var currentTotal = parseFloat(totalElement.innerText);

            var newTotal = currentTotal + (quantity * price);
            totalElement.innerText = newTotal.toFixed(2); // แสดงราคารวมใหม่โดยมีทศนิยม 2 ตำแหน่ง
        }
    </script>
</asp:Content>
