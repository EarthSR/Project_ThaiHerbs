using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        User user = ConnectionClass.LoginUser(txtusername.Text,txtpassword.Text);
        if (user != null)
        {
            Session["Login"] = user.UserName;
            Session["Type"] = user.UserType;
            Session["Password"] = user.Password;
            Session["Email"] = user.Email;
            Session["Phone"] = user.Phone;
            Session["Birthday"] = user.Birthday;
            Session["Firstname"] = user.FirstName;
            Session["Lastname"] = user.LastName;
            Session["Address"] = user.Address;
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            lblerror.Text = "Login failed!!!";
        }
    }
}