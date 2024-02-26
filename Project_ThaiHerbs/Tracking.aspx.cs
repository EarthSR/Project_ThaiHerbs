using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tracking : System.Web.UI.Page
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
        List<Delivery> deliveries = ConnectionClass.GetDeliveries(userid);
        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Tracking.css'>");
        sb.Append("<div class='tracking'>");

        foreach (Delivery delivery in deliveries)
        {
            sb.Append(string.Format(@" 
            <div class='content'>
                <img id='mainImage' src='{0}' class='imgtracking' />
                <p>{1}</p>
            </div>
            <div class='content'>
                <p>{2}</p>
            </div>
            <div class='content'>
                <p>{3}</p>
            </div>
            <div class='content'>
                <p>{4}</p>
            </div>",
                delivery.ProductImage,
                delivery.ProductName,
                delivery.DeliveryName,
                delivery.TrackingID,
                delivery.OrderStatus
            ));
        }

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }


}