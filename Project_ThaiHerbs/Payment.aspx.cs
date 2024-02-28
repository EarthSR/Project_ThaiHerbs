using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            qrImage.Visible = false;
            if (Session["userid"] != null)
            {
                int userid = (int)Session["userid"];
                FillPage(userid);
                FillTopPage(userid);
            }
        }
    }

    private void FillPage(int userid)
    {

        List<orderdetial> ordertetailList = ConnectionClass.GetOrderDetailById(userid);

        StringBuilder sb = new StringBuilder();
        
        foreach (orderdetial orderdetail in ordertetailList)
        {
            sb.Append("<div class='payment-boxdetail'>");
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
            sb.Append("</div>");
        }
       

        
        lblshow.Text = sb.ToString();
    }


    protected void lbl1_Click1(object sender, EventArgs e)
    {
        txtaddress.Visible = true;
        btncancel.Visible = true;
        btnupdate.Visible = true;
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
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        if (Session["userid"] != null)
        {
            int userids = (int)Session["userid"];
            List<Product> productList = ConnectionClass.GetProductsByUserId(userids);

            double totalPrice = 0;
            int totalAmount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // เริ่มต้นด้วยการสร้าง transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (Product product in productList)
                    {
                        totalPrice += (product.Price * product.Amount);
                        totalAmount += product.Amount;
                    }

                    // เพิ่มข้อมูลรายการในตาราง orders และดึง order_id ที่เพิ่มล่าสุด
                    string insertOrderQuery = @"INSERT INTO orders (userid_fk, ordersdate, totalamount, totalprice) 
                                             OUTPUT INSERTED.orderid 
                                             VALUES (@CustomerId, GETDATE(), @AmountOfPro, @TotalPrice);";

                    SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection, transaction);
                    insertOrderCommand.Parameters.AddWithValue("@CustomerId", userids);
                    insertOrderCommand.Parameters.AddWithValue("@AmountOfPro", totalAmount);
                    insertOrderCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    int orderId = (int)insertOrderCommand.ExecuteScalar();

                    foreach (Product product in productList)
                    {
                        string insertOrderDetailQuery = @"INSERT INTO orderdetail (productid_fk, priceofproduct, userid, amount, status, orderid_fk) 
                                                     VALUES (@ProductId, @Price, @UserId, @Quantity, @Status, @OrderId);";

                        SqlCommand insertOrderDetailCommand = new SqlCommand(insertOrderDetailQuery, connection, transaction);
                        insertOrderDetailCommand.Parameters.AddWithValue("@OrderId", orderId);
                        insertOrderDetailCommand.Parameters.AddWithValue("@ProductId", product.Id);
                        insertOrderDetailCommand.Parameters.AddWithValue("@UserId", userids);
                        insertOrderDetailCommand.Parameters.AddWithValue("@Status", "Waiting for payment");
                        insertOrderDetailCommand.Parameters.AddWithValue("@Quantity", product.Amount);
                        insertOrderDetailCommand.Parameters.AddWithValue("@Price", product.Price);
                        ConnectionClass.UpdateAvailableQuantity(product.Id,product.Amount);
                        insertOrderDetailCommand.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    Session["orderid"] = orderId;

                    ConnectionClass.DeleteCartItem(userids);
                    
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        int orderid = (int)Session["orderid"];
        int userid = (int)Session["userid"];
        string selectedValue = DropDownList1.SelectedValue;
        string img = uploadedImage.ImageUrl;
        ConnectionClass.Insertpayment(orderid, userid, DateTime.Now, selectedValue,img);
        lblt.Text = ConnectionClass.Updatestatus("Waiting to check",userid,orderid);
        lblt.Visible = true;
        FillPage(userid);
        FillTopPage(userid);
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
                uploadedImage.ImageUrl = "~/Slippay/" + fileName;

                // เมื่อมีการอัพโหลดไฟล์ใหม่ให้เปิดปุ่ม ButtonPayment
                Button2.Visible = true;

            }
            catch (Exception ex)
            {
                // จัดการข้อผิดพลาดที่เกิดขึ้นในการอัพโหลด
                Response.Write("Error: " + ex.Message);
            }
        }
    }



    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int userid = (int)Session["userid"];
        ConnectionClass.Updateaddress(userid,txtaddress.Text);
        btncancel.Visible = false;
        btnupdate.Visible = false;
        txtaddress.Visible = false;
        FillPage(userid);
        FillTopPage(userid);
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        int userid = (int)Session["userid"];
        btnupdate.Visible = false;
        txtaddress.Visible = false;
        btncancel.Visible = false;
        FillPage(userid);
        FillTopPage(userid);
    }




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string select = DropDownList1.SelectedValue;
        if (select == "QR payment")
        {
            qrImage.Visible = true;
        }
        else
        {
            qrImage.Visible = false;
        }
    }
}

