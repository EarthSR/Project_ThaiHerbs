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

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminProduct.aspx");
    }
    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminEdit.aspx");
    }
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminDelete.aspx");
    }


    protected void ButtonDelivery_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminSellList.aspx");
    }
    
}