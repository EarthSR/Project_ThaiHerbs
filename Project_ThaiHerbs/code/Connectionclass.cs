using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Timers;
using System.Text;
/// <summary>
/// Summary description for Connectionclass
/// </summary>
public class Connectionclass
{
    private static SqlConnection conn;
    private static SqlCommand command;
    public Connectionclass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebCSCPCConnectionString"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }
}