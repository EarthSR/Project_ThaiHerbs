using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSell : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    {
        StringBuilder sb = new StringBuilder();

        // Connection string to your SQL Server database
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();

        // Query to fetch data from orders table with specific condition
        string query = @"SELECT o.orderid, o.userid_fk, o.totalprice, o.totalamount, od.status
                     FROM orders o
                     INNER JOIN orderdetail od ON o.orderid = od.orderid_fk
                     WHERE od.status = 'Waiting for packing'"; // Make sure to handle Unicode characters properly

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
                        <td>Total Price</td>
                        <td>Total Amount</td>
                        <td>Status</td>
                    </tr>");

                // Append table rows dynamically based on data retrieved from the database
                while (reader.Read())
                {
                    sb.Append("<tr>");
                    sb.Append("<td>").Append(reader["orderid"]).Append("</td>");
                    sb.Append("<td>").Append(reader["userid_fk"]).Append("</td>");
                    sb.Append("<td>").Append(reader["totalprice"]).Append("</td>");
                    sb.Append("<td>").Append(reader["totalamount"]).Append("</td>");
                    sb.Append("<td>").Append(reader["status"]).Append("</td>");
                    sb.Append("</tr>");
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

        // Display the HTML in lblshow
        lblshow.Text = sb.ToString();
    }

    private static readonly ThreadLocal<Random> random =
        new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        // Generate a random tracking ID
        int trackingId = random.Value.Next();

        // Update status
        lblerror.Text = ConnectionClass.UpdateStatus(Convert.ToInt32(txtid.Text), "Waiting for packing", "Waiting to receive the product");

        // Insert delivery
        if (!string.IsNullOrEmpty(txtid.Text) && !string.IsNullOrEmpty(DropDownList1.SelectedValue))
        {
            int orderId = Convert.ToInt32(txtid.Text);
            int paymentId = ConnectionClass.GetPaymentId(orderId);
            DateTime deliveryDate = DateTime.Now;
            string deliveryName = DropDownList1.SelectedValue;

            string insertionResult = ConnectionClass.InsertDelivery(paymentId, trackingId, deliveryDate, deliveryName);
            // Handle insertion result if needed
        }
    }


}