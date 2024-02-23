using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/.css'/>");

        // Append product details for each product in the list
        sb.Append("<div class='cart-product'>");
        int inputCounter = 0; // เพิ่มตัวแปรนับจำนวน input
        foreach (Product product in productList)
        {
            inputCounter++; // เพิ่มค่าตัวนับทุกครั้งที่วนลูป
            sb.AppendFormat(@"
            <table style='width: 100%;'>
                <tr>
                    <td class='auto-style1'>
                        <label class='material-checkbox'>
                            <input type='checkbox' class='auto-style1'>
                            <span class='checkmark'></span>
                        </label>
                    </td>
                    <td class='cart-product-img'>
                        <img src='{0}' class='cart-product-img'/>
                    </td>
                    <td class='cart-nameproduct'>&nbsp;&nbsp;&nbsp;&nbsp;<a>{1}</a></td>
                    <td><a>{2} บาท</a></td>
                    <td>
                        <div class='quantity buttons_added'>
                            <input type='text' id='quantityInput{3}' class='input-text qty text' value='1' style='width: 53px; height: 24px;' pattern='\d*' inputmode='numeric' />
                        </div>
                    </td>
                </tr>
            </table>
        ",
                product.Image, product.Name, product.Price, inputCounter); // ใส่ค่าตัวนับใน ID ของ input
        }
        sb.Append("</div>");

        // Set the generated HTML to the label
        lblshow.Text = sb.ToString();
    }


}