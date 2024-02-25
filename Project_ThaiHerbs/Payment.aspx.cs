using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    int orderid = 0;
    int userid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (uploadedImage.ImageUrl != null)
            {
                ButtonPayment.Visible = true;
            }
            else
            {
                ButtonPayment.Visible = false;
            }

            if (Session["userid"] != null)
            {
                userid = (int)Session["userid"];
                FillPage(userid);
                FillTopPage(userid);
                if (Request.QueryString["orderId"] != null)
                {
                    // Retrieve the orderId from the query string
                    orderid = Convert.ToInt32(Request.QueryString["orderId"]);



                }
            }
        }
    }

    private void FillPage(int userid)
    {

        List<orderdetial> ordertetailList = ConnectionClass.GetOrderDetailById(userid);

        StringBuilder sb = new StringBuilder();
        sb.Append("<div class='payment-boxdetail'>");
        foreach (orderdetial orderdetail in ordertetailList)
        {
            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<img src='{0}' class='imgpayment' />", orderdetail.Image);
            sb.Append("</div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-name'>{0}</p>", orderdetail.Name);
            sb.Append("</div>");

            sb.Append("<div class='payment-boxdetail2'><p></p></div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-price'>{0}<a>บาท</a></p>", orderdetail.Priceofproduct);
            sb.Append("</div>");

            sb.Append("<div class='payment-boxdetail2'>");
            sb.AppendFormat("<p class='product-price'>{0}<a>ชิ้น</a></p>", orderdetail.Amount);
            sb.Append("</div>");
        }
        sb.Append("</div>");

        sb.Append("</div>");
        lblshow.Text = sb.ToString();
    }



    protected void lbl1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/ProfileUser.aspx");
    }


    private void FillTopPage(int userid)
    {
        // Initialize StringBuilder
        StringBuilder sb = new StringBuilder();

        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE userid = @UserId", conn);
            command.Parameters.AddWithValue("@UserId", userid);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Populate controls with user data
                    string username = reader["username"].ToString();
                    string phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "";
                    string address = reader["address"] != DBNull.Value ? reader["address"].ToString() : "";

                    // Append user data to StringBuilder
                    sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Payment.css'/>");

                    sb.AppendFormat("<p>📍 ที่อยู่ในการจัดส่ง</p>");
                    sb.AppendFormat("<p><a>{0}: {1}</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", username, phone);
                    sb.AppendFormat("<a>ที่อยู่ : {0}</a>", address);
                    sb.Append("<a><asp:LinkButton ID='lbl1' runat='server' Text='เปลี่ยน' OnClick='lbl1_Click1'/></a>");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error loading user data: " + ex.Message);
            }
        }

        // Set the HTML content to your control
        lbltop.Text = sb.ToString();
    }


    protected void ButtonPayment_Click(object sender, EventArgs e)
    {
        string selectedValue = DropDownList1.SelectedValue;
        ConnectionClass.Insertpayment(orderid, userid, DateTime.Now, "QR Code");
        lblt.Text = ConnectionClass.Updatestatus("Waiting to check",userid,orderid);
        lblt.Visible = true;
        
    }


    protected void ButtonUpload_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile)
        {
            try
            {
                // บันทึกรูปภาพลงในโฟลเดอร์ ImgHerb ของโปรเจค
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string filePath = Server.MapPath("~/Slippay/") + fileName;
                FileUpload1.SaveAs(filePath);

                // กำหนด src attribute ของ <img> tag เพื่อแสดงรูปภาพที่อัพโหลด
                uploadedImage.ImageUrl = "~/Slippay/" +fileName;
            }
            catch (Exception ex)
            {
                // จัดการข้อผิดพลาดที่เกิดขึ้นในการอัพโหลด
                Response.Write("Error: " + ex.Message);
            }

        }
    }
}
