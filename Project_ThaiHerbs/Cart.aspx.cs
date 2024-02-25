using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Cart : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                    int userid = (int)Session["userid"];
                    FillPage(userid);
            }
        }
    }
    private void FillPage(int userid)
    {
        ArrayList productList = ConnectionClass.GetProductsByUserId(userid);

        StringBuilder sb = new StringBuilder();

        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Cart.css'/>");

        // Append product details for each product in the list
        sb.Append("<div class='cart-product'>");
        double totalPrice = 0; // Variable to store total price
        int totalAmount = 0;
        foreach (Product product in productList)
        {
            sb.AppendFormat(@"
<table style='width: 100%;'>
    <tr>
        
        <td class='cart-product-img'>
            <img src='{1}' class='cart-product-img'/>
        </td>
        <td class='cart-nameproduct'>&nbsp;&nbsp;&nbsp;&nbsp;<a>{2}</a></td>
        <td><a id='price{0}'>{3} บาท</a></td>
        <td><a>จำนวน {4} ชิ้น</a></td>
        <td>
         <a></a>
        </td>
    </tr>
</table>
", product.Id, product.Image, product.Name, product.Price, product.Amount);

            // Add the price of the current product to the total price
            totalPrice += (product.Price * product.Amount);
            totalAmount += product.Amount;
        }

        sb.Append("</div>");

        // Set the generated HTML to the label
        lblshow.Text = sb.ToString();

        // Display the total price
        lbltotal.Text = "ราคารวม : " + totalPrice.ToString() + " บาท";
        lblbamount.Text = "จำนวนทั้งหมด : " + totalAmount.ToString() + " ชิ้น";
    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int userid = (int)Session["userid"];
        lblresult.Text = ConnectionClass.DeleteCartItem(userid);
        FillPage(userid);
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        // เช็คก่อนว่าผู้ใช้เข้าสู่ระบบหรือยัง
        if (Session["userid"] != null)
        {
            int userid = (int)Session["userid"];

            // ดึงรายการสินค้าในตะกร้าของผู้ใช้
            ArrayList productList = ConnectionClass.GetProductsByUserId(userid);

            // วนลูปผ่านรายการสินค้าในตะกร้า
            foreach (Product product in productList)
            {
                // ทำการลดจำนวนสินค้าในคลังตามจำนวนที่มีในตะกร้า
                ConnectionClass.UpdateAvailableQuantity(product.Id, product.Amount);
            }

            // เมื่อตัดสินค้าออกจากคลังเรียบร้อยแล้ว สามารถลบรายการสินค้าในตะกร้าของผู้ใช้ทิ้งได้
            ConnectionClass.ClearCart(userid);

            // หลังจากนั้นเรียกใช้ฟังก์ชัน FillPage เพื่ออัปเดตข้อมูลที่แสดงใหม่บนหน้าเว็บ
            FillPage(userid);
        }
    }




}