using System;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void txtusername_TextChange(object sender, EventArgs e)
    {
        int valueMessage = ConnectionClass.ValidUser(txtusername.Text);
        if (valueMessage == 0)
        {
            txtusername.Text = "";
            lblCheck.Text = "Username already exists. Please choose a different one.";
        }
        else
        {
            lblCheck.Text = "Username available.";
        }
    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {

            string gender = DropDownList1.SelectedValue;
            User user = new User(txtusername.Text, txtpassword.Text, txtemail.Text, "1", gender);
            lblresult.Text = ConnectionClass.RegisterUser(user);
            Thread.Sleep(5000);
            Server.Transfer("~/Account/Login.aspx");
    }


}
