
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Cart : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["userid"] != null)
            {
                int userid = (int)Session["userid"];
                List<Product> productList = ConnectionClass.GetProductsByUserId(userid);
                if (productList.Count != 0)
                {
                    btbcon.Visible = true;
                }
                FillPage(userid);
            }
        }
    }
    private void FillPage(int userid)
    {
        List<Product> productList = ConnectionClass.GetProductsByUserId(userid);

        StringBuilder sb = new StringBuilder();

        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/Cart.css'/>");

        // Append product details for each product in the list
        sb.Append("<div class='cart-product'>");
        double totalPrice = 0; // Variable to store total price
        int totalAmount = 0;
        foreach (Product product in productList)
        {
            sb.AppendFormat(@"
<table style='width: 100%;'>
    <tr>
        
        <td class='cart-product-img'>
            <img src='{1}' class='cart-product-img'/>
        </td>
        <td class='cart-nameproduct'>&nbsp;&nbsp;&nbsp;&nbsp;<a>{2}</a></td>
        <td><a id='price{0}'>{3} บาท</a></td>
        <td><a>จำนวน {4} ชิ้น</a></td>
        <td>
         <a></a>
        </td>
    </tr>
</table>
", product.Id, product.Image, product.Name, product.Price, product.Amount);

            // Add the price of the current product to the total price
            totalPrice += (product.Price * product.Amount);
            totalAmount += product.Amount;
        }

        sb.Append("</div>");

        // Set the generated HTML to the label
        lblshow.Text = sb.ToString();

        // Display the total price
        lbltotal.Text = "ราคารวม : " + totalPrice.ToString() + " บาท";
        lblbamount.Text = "จำนวนทั้งหมด : " + totalAmount.ToString() + " ชิ้น";

    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int userid = (int)Session["userid"];
        lblresult.Text = ConnectionClass.DeleteCartItem(userid);
        FillPage(userid);
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        if (Session["userid"] != null)
        {
            int userid = (int)Session["userid"];
            List<Product> productList = ConnectionClass.GetProductsByUserId(userid);

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
                    insertOrderCommand.Parameters.AddWithValue("@CustomerId", userid);
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
                        insertOrderDetailCommand.Parameters.AddWithValue("@UserId", userid);
                        insertOrderDetailCommand.Parameters.AddWithValue("@Status", "Waiting for payment");
                        insertOrderDetailCommand.Parameters.AddWithValue("@Quantity", product.Amount);
                        insertOrderDetailCommand.Parameters.AddWithValue("@Price", product.Price);

                        insertOrderDetailCommand.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    ConnectionClass.DeleteCartItem(userid);
                    // โหลดข้อมูลใหม่และเรียกหน้า Payment.aspx
                    Response.Redirect("~/Payment.aspx?orderId=" + orderId);
                }
                catch (Exception ex)
                {
                    // สามารถทำการ log หรือแจ้งเตือนเพิ่มเติมได้ตามความเหมาะสม
                    lblresult.Text = "An error occurred: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }




}





