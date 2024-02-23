<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSearch.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
    <div class ="cart-container">
    <div class = "cart-top ">
        <div class ="chkbox">
        <label class="material-checkbox">
        <input type="checkbox" class="auto-style1">
        <span class="checkmark"></span>
        เลือกสินค้าทั้งหมด
      </label>
            </div>
     </div>  
        





    <div class = "cart-product">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                      <label class="material-checkbox">
                    <input type="checkbox" class="auto-style1">
                      <span class="checkmark"></span>
                    </label>

                </td>
                <td class= "cart-product-img">
                    <img src="ImgHerb/กัญชา.jpg" Class ="cart-product-img"/>
                </td>
            <td class = "cart-nameproduct">
                 &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblline" runat="server" Text="กัญชาแปรรูปพร้อมใช้งาน" />
            </td>
                <td>
                <asp:Label ID="Label1" runat="server" Text=" 800 บาท" />
                </td>
                <td>
                    <div class="quantity buttons_added">
                    <asp:Button ID="minusButton" runat="server" Text="-" CssClass="minus" OnClientClick="return decreaseQuantity();" style="width: 40px; height: 26px;" />
                    <asp:TextBox ID="quantityInput" runat="server" Text="1" CssClass="input-text qty text" Width="53px" Height="24px" pattern="\d*" inputmode="numeric" />
                    <asp:Button ID="plusButton" runat="server" Text="+" CssClass="plus" OnClientClick="return increaseQuantity();" style="width: 40px; height: 26px;" />
                    </div>

                </td>
            </tr>
        </table>
        </div>
        
        
        


        
      
        <div class ="btn">
            <asp:Label ID="Label3" runat="server" Text="ราคารวม :" />
                <asp:Label ID="Label2" runat="server" Text="(000)  ฿" />&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button runat="server" Text="สั่งซื้อ" CssClass="btncart" />
        </div>
    </div>
</asp:Content>

