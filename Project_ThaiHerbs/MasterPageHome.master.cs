using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] != null)
        {
            login.Text = Session["Login"].ToString();
            register.Text = "Logout";
            register.Click -= register_Click; // Remove the register click event handler
            register.Click += Logout_Click; // Attach the logout click event handler
        }
        else
        {
            login.Text = "Login";
            register.Text = "Register";
            register.Click -= Logout_Click; // Remove the logout click event handler
            register.Click += register_Click; // Attach the register click event handler
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        if (login.Text == "Login")
        {
            Response.Redirect("~/Account/Login.aspx"); 
        }
     
    }

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Register.aspx"); 
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Clear(); 
        Response.Redirect("~/Home.aspx"); 
    }
}
