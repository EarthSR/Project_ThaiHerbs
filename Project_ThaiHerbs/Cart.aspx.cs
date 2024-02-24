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
        int inputCounter = 0;
        foreach (Product product in productList)
        {
            inputCounter++; 
            sb.AppendFormat(@"
    <table style='width: 100%;'>
        <tr>
            <td class='cart-product-img'>
                <img src='{0}' class='cart-product-img'/>
            </td>
            <td class='cart-nameproduct'>&nbsp;&nbsp;&nbsp;&nbsp;<a>{1}</a></td>
            <td><a id='price{3}'>{2} บาท</a></td>
            <td>
                <div class='quantity buttons_added'>
                    <input type='text' id='quantityInput{3}' class='input-text qty text' style='width: 53px; height: 24px;' pattern='\d*' inputmode='numeric' onchange='calculateTotal({3})'/>
                </div>
            </td>
        </tr>
    </table>
",
            product.Image, product.Name, product.Price, inputCounter);
        }

            sb.Append("</div>");

        // Set the generated HTML to the label
        lblshow.Text = sb.ToString();
    }
    
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int userid = (int)Session["userid"];
        lblresult.Text = ConnectionClass.DeleteCartItem(userid);

    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static int GetAvailableQuantity(int productId)
    {
        int availableQuantity = ConnectionClass.getprobyid(productId);
        return availableQuantity;
    }
}