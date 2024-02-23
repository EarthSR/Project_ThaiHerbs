using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;

public partial class MasterPageHome : System.Web.UI.MasterPage
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
        string searchQuery = txtsearch.Text;
        Session["search"] = searchQuery;
        Response.Redirect("~/Home.aspx");
    }


    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
      
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        LinkButton clickedButton = (LinkButton)sender;
        Session["selectedtype"] = clickedButton.Text;
        Response.Redirect("~/selecttype.aspx");
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Session["Login"] != null)
        {
            Response.Redirect("~/Cart.aspx");
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}
