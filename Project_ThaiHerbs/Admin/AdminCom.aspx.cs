using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminCom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    {
        double totalPrice = 0.0;
        int totalAmount = 0;
        StringBuilder sb = new StringBuilder();

        // Connection string to your SQL Server database
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();

        // Query to fetch data from orders table with specific condition
        string query = @"SELECT o.orderid, o.userid_fk, od.priceofproduct, od.amount, od.status, product.pname
                 FROM orders o
                 INNER JOIN orderdetail od ON o.orderid = od.orderid_fk
                 JOIN payment ON payment.orderid_fk = o.orderid
                 JOIN product ON product.productid = od.productid_fk
                 WHERE od.status = 'review'"; // Make sure to handle Unicode characters properly

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Append table header
                sb.Append(@"
            <table style='width:100%;'>
                <tr>
                    <td>Order ID</td>   
                    <td>User ID</td>
                    <td>Price</td>
                    <td>Amount</td>
                    <td>Status</td>
                    <td>Orderdetail Name</td>
                </tr>");

                // Append table rows dynamically based on data retrieved from the database
                while (reader.Read())
                {
                    sb.Append("<tr>");
                    sb.Append("<td>").Append(reader["orderid"]).Append("</td>");
                    sb.Append("<td>").Append(reader["userid_fk"]).Append("</td>");
                    sb.Append("<td>").Append(reader["priceofproduct"]).Append("</td>");
                    sb.Append("<td>").Append(reader["amount"]).Append("</td>");
                    sb.Append("<td>").Append(reader["status"]).Append("</td>");
                    sb.Append("<td>").Append(reader["pname"]).Append("</td>");

                    sb.Append("</tr>");

                    // Increment total price and amount
                    totalPrice += Convert.ToDouble(reader["priceofproduct"]);
                    totalAmount += Convert.ToInt32(reader["amount"]);
                }

                sb.Append("</table>");
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }
        }

        // Append total price and amount to the table
        sb.Append("<div>Total Price: ").Append(totalPrice.ToString("C")).Append("</div>");
        sb.Append("<div>Total Amount: ").Append(totalAmount).Append("</div>");

        // Display the HTML in lblshow
        lblshow.Text = sb.ToString();
    }


}