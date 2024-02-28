using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                int userid = Convert.ToInt32(Session["userid"]);
                FillPage(userid);

            }

        }
    }

    private void FillPage(int userid)
    {
        List<Delivery> deliveries = ConnectionClass.Getorderhistory(userid);
        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Tracking.css'>");

        foreach (Delivery delivery in deliveries)
        {
            sb.Append("<div class='tracking'>");
            sb.Append("<div class='content'>");
            sb.Append("<img id='mainImage' src='" + delivery.ProductImage + "' class='imgtracking' />");
            sb.Append("<p>" + delivery.ProductName + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.DeliveryName + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.Amount + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.Price + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.Daterecevied + "</p>");
            sb.Append("</div>");
            sb.Append("</div>");

        }


        lblshow.Text = sb.ToString();
    }
}