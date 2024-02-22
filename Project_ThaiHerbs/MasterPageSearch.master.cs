using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageSearch : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] != null)
        {
            user.Text = Session["Login"].ToString();
            login.Visible = false;
            register.Visible = false;
            user.Visible = true;
            Logout.Visible = true;

        }
        else
        {
            login.Visible = true;
            register.Visible = true;
            user.Visible = false;
            Logout.Visible = false;
        }
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Home.aspx");
    }

    protected void search_Click(object sender, EventArgs e)
    {
        string search = txtsearch.Text;
        Session["search"] = search;
        ConnectionClass.Searchbar(search);
    }
}
