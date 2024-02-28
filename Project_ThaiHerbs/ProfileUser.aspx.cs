using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                int userid = Convert.ToInt32(Session["userid"]);
                lblresult.Text = userid.ToString();
                LoadUserData(userid); // Call the method to load user data
            }
            // Other code for populating controls goes here
        }
    }



    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt32(Session["userid"]);

        string Password = password.Text; // Assuming 'password' is the ID of your password TextBox
        string Email = email.Text; // Assuming 'email' is the ID of your email TextBox
        string Phone = phone.Text; // Assuming 'phone' is the ID of your phone TextBox
        string FirstName = firstname.Text; // Assuming 'firstname' is the ID of your firstname TextBox
        string LastName = Lastname.Text; // Assuming 'Lastname' is the ID of your lastname TextBox
        string Address = address.Text; // Assuming 'address' is the ID of your address TextBox

        // Update user data
        lblresult.Text = ConnectionClass.UpdateUserData(userid, FirstName, LastName, Address, Phone, Email, Password);

        // Refresh session variables
        Session["Firstname"] = FirstName;
        Session["Lastname"] = LastName;
        Session["Address"] = Address;
        Session["Phone"] = Phone;
        Session["Email"] = Email;
        Session["gender"] = gender;
    }

    private void LoadUserData(int userId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE userid = @UserId", conn);
            command.Parameters.AddWithValue("@UserId", userId);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Populate controls with user data
                    username.Text = reader["username"].ToString();
                    password.Text = reader["password"].ToString();
                    email.Text = reader["email"].ToString();
                    phone.Text = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "";
                    firstname.Text = reader["firstname"] != DBNull.Value ? reader["firstname"].ToString() : "";
                    Lastname.Text = reader["lastname"] != DBNull.Value ? reader["lastname"].ToString() : "";
                    address.Text = reader["address"] != DBNull.Value ? reader["address"].ToString() : "";
                    gender.Text = reader["gender"] != DBNull.Value ? reader["gender"].ToString() : "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                //lblresult.Text = "Error loading user data: " + ex.Message;
            }
        }
    }

}