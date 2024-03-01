using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page

{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] != null)
        {
            if (Session["usertype"].ToString() == "owner")
            {

                btndelivery.Visible = false;
                btnupdate.Visible = false;
                btnorder.Visible = false;
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }


}