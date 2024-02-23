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
                <a href='ProductDetail.aspx?productId={0}' target='_blank' class='product-card'> <!-- Modified to open in new page -->
                    <div class='product-image'>
                        <img src='{1}'/>
                    </div>
                    <div class='product-details'>
                        <h2>{2}</h2>
                        <div class='price'>${3}</div>
                    </div>
                </a>
            </div>",
                product.Id, product.Image, product.Name, product.Price));

        }

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }

}
