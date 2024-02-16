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
            Session["type"] = user.UserType;
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            lblerror.Text = "Login failed!!!";
        }
    }
}