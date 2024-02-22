using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class selecttype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the selected type from the query string
            string type = (string)Session["selectedtype"];

            // Fill the page with products based on the selected type
            FillPage(type);
        }
    }

    private void FillPage(string type)
    {
        // Get the list of products based on the selected type
        ArrayList productList = ConnectionClass.GetproductByType(type);

        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Product.css'/>");
        sb.Append("<div id='product-container'>");

        foreach (Product product in productList)
        {
            sb.Append(string.Format(@"
                <div class='box'>
                    <div class='product-card'>
                        <div class='product-image'>
                            <img src='{0}'/>
                        </div>
                        <div class='product-details'>
                            <h2>{1}</h2>
                            <p>{2}</p>
                            <div class='price'>${3}</div>
                            <p>Total amount {4}</p>
                        </div>
                    </div>
                </div>",
                product.Image, product.Name, product.Pdetail, product.Price, product.Amount));
        }

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }
}
