using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
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
        List<orderdetial> ordertetailList = ConnectionClass.GetOrderDetailById(userid);

        StringBuilder sb = new StringBuilder();

        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Payment.css'/>");

        // Append product details for each product in the list
        sb.Append("<div class='payment-boxdetail'>");
        foreach (orderdetial orderdetail in ordertetailList)
        {
            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<img src='{0}' class='imgpayment' />", orderdetail.Image);
            sb.Append("</div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-name'>{0}</p>", orderdetail.Name);
            sb.Append("</div>");

            sb.Append(" <div class='payment-boxdetail2'><p></p></div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-price'>{0}<a>บาท</a></p>", orderdetail.Priceofproduct);
            sb.Append("</div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-price'>{0}<a>ชิ้น</a></p>", orderdetail.Amount);
            sb.Append("</div>");
        }

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }


    protected void lbl1_Click(object sender, EventArgs e)
    {

    }
}