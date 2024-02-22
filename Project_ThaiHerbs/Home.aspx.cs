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
        if (!IsPostBack)
        {
            if (Session["search"] == null)
            {
                FillPage();
            }
            else
            {
                string searchQuery = Session["search"].ToString();
                FillPageWithSearchResults(searchQuery);
                Session.Remove("search");
            }
        }
    }

    private void FillPageWithSearchResults(string searchQuery)
    {
        ArrayList productList = ConnectionClass.Searchbar(searchQuery);

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

    private void FillPage()
    {
        ArrayList productlist = ConnectionClass.GetproductByType("%");

        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Product.css'/>");
        sb.Append("<div id='product-container'>");
        foreach (Product product in productlist)
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