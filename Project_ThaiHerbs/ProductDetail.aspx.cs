using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["productId"] != null)
            {
                // Get the value of the productId parameter from the query string
                int productId;
                if (int.TryParse(Request.QueryString["productId"], out productId))
                {
                    FillPage(productId);
                }
            }
        }
    }
    private void FillPage(int pid)
    {
        ArrayList productList = ConnectionClass.getproid(pid);

        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/test.css'/>");
        sb.Append("<div id='product-container'>");

        foreach (Product product in productList)
        {
            sb.Append(string.Format(@" 
            <div class='detail-image'>
                <img src='{0}' />
            </div>
            <div class='detail-info'>
                <h2>{1}</h2>
                <h3>{2}</h3>
                <a>${3}</a>
                <br />
                <br />
                <div class='quantity buttons_added'>
                    <a>
                        <label for='quantityInput'>จำนวน : </label>
                    </a>
                    <button type='button' class='minus' onclick='return decreaseQuantity();'>-</button>
                    <asp:TextBox ID='quantityInput' runat='server' CssClass='input-text qty text' Text='1'
                        Width='53px' Height='24px' pattern='\d*' inputmode='numeric' />
                    <button type='button' class='plus' onclick='return increaseQuantity();'>+</button>
                </div>
                <br />
                <br />
                <div class='buttons'>
                    <asp:Button runat='server' Text='Add to Cart' CssClass='btn-adddetail' />
                    <asp:Button runat='server' Text='Back to shop' CssClass='btn-adddetail' />
                </div>
            </div>",
                product.Image, product.Name, product.Pdetail, product.Price));
        }

        sb.Append("</div>");
        LiteralControl productControl = new LiteralControl(sb.ToString());
        productContainer.Controls.Add(productControl);
    }


}