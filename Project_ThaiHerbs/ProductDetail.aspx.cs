using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                int productId;
                if (int.TryParse(Request.QueryString["productId"], out productId))
                {
                    Session["ProductId"] = productId;
                    FillPage(productId);
                }
            }
        }
    }
    private void FillPage(int pid)
    {
        ArrayList productList = ConnectionClass.getproid(pid);

        StringBuilder sb = new StringBuilder();
        sb.Append("<script src='~/JS/Productdetail.js'></script>");
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/ProductDetail.css'/>");
        foreach (Product product in productList)
        {
            sb.Append(string.Format(@" 
            <div class='detail-image'>
                <img src='{0}' class='detail-img'/>
            </div>
            <div class='detail-image'>
                <h2>{1}</h2>
                <h3>{2}</h3>
                <a>${3}</a>
                <br />
                <br />
               ",
                product.Image, product.Name, product.Pdetail, product.Price));
        }

        LiteralControl productControl = new LiteralControl(sb.ToString());
        productContainer.Controls.Add(productControl);
    }
    protected void decreaseQuantity_Click(object sender, EventArgs e)
    {
        int currentValue = int.Parse(quantityInput.Text);
        if (currentValue > 1)
        {
            quantityInput.Text = (currentValue - 1).ToString();
        }
    }

    protected void increaseQuantity_Click(object sender, EventArgs e)
    {
        int currentValue = int.Parse(quantityInput.Text);
        quantityInput.Text = (currentValue + 1).ToString();
    }

}