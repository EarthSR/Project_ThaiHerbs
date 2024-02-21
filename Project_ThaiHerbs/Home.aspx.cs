using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    {
        ArrayList productlist = new ArrayList();
        if (!IsPostBack)
        {
            productlist = ConnectionClass.GetproductByType("%");
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Product.css'/>");
        foreach ( Product product in productlist)
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
        lblshow.Text = sb.ToString();
    }

}