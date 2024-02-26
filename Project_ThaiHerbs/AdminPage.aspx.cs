using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonAdd(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/AdminProduct.aspx");
    }
    protected void ButtonEdit(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/AdminEdit.aspx");
    }
    protected void ButtonDelete(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/AdminDelete.aspx");
    }
}