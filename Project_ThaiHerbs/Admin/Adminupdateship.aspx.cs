using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Adminupdateship : System.Web.UI.Page
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
        string query = @"SELECT o.orderid, o.userid_fk, o.totalprice, o.totalamount, od.status, payment.slip
                     FROM orders o
                     INNER JOIN orderdetail od ON o.orderid = od.orderid_fk
					 join payment on payment.orderid_fk = o.orderid
                     WHERE od.status = 'Waiting to receive the product'"; // Make sure to handle Unicode characters properly

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
    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        ConnectionClass.UpdateStatus(Convert.ToInt32(txtid.Text), "Waiting to receive the product", "Successful delivery");
        FillPage();
    }
}