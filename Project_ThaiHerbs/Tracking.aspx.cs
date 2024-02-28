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
            sb.Append("<div class='content'>");
            sb.Append("<img id='mainImage' src='" + delivery.ProductImage + "' class='imgtracking' />");
            sb.Append("<p>" + delivery.ProductName + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.DeliveryName + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.TrackingId + "</p>");
            sb.Append("</div>");
            sb.Append("<div class='content'>");
            sb.Append("<p>" + delivery.OrderStatus + "</p>");
            sb.Append("</div>");

        }

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }

    protected void btbr_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt32(Session["userid"]);
        List<Delivery> deliveries = ConnectionClass.GetDeliveries(userid);

        foreach (Delivery delivery in deliveries)
        {
            if (delivery.OrderStatus == "Successful delivery")
            {
                // เรียกใช้เมทอด UpdateStatus เพื่ออัปเดตสถานะ
                string result = ConnectionClass.UpdateStatus(delivery.Orderdetailid, "Successful delivery", "review");
                // ตรวจสอบผลลัพธ์จากการอัปเดต
                if (result.StartsWith("Rows affected"))
                {
                    // สามารถอัปเดตสถานะสำเร็จ
                    // ทำการรีโหลดหน้าหรือปรับปรุงส่วนแสดงผลตามที่ต้องการ
                    FillPage(userid); // โหลดข้อมูลใหม่หลังจากการอัปเดต
                    lblerror.Text = "Compleate!!!";
                }
                else
                {
                    lblerror.Text = "Something Wrong";
                    // เกิดข้อผิดพลาดในการอัปเดตสถานะ
                    // จัดการกับข้อผิดพลาดตามที่ต้องการ
                    // เช่น lblMessage.Text = "Update failed: " + result;
                }
            }
        }
    }

}