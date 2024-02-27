using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtserch_TextChanged(object sender, EventArgs e)
    {
        List<Product> productList = ConnectionClass.Getproduct(txtserch.Text);

        if (productList.Count > 0)
        {
            Product product = productList[0];

            txtname.Text = product.Name;
            txtamount.Text = product.Amount.ToString();
            txtprice.Text = product.Price.ToString();
            txtdetail.Text = product.Pdetail;
            DropDownList1.SelectedValue = product.Type;
            uploaded1.ImageUrl = ResolveUrl("~/ImgHerb/" + product.Image);

            txtname.Enabled = true;
            txtamount.Enabled = true;
            txtprice.Enabled = true;
            txtdetail.Enabled = true;
            DropDownList1.Enabled = true;
            FileUpload1.Enabled = true;
        }
        else
        {
            // Clear controls if no product is found
            txtname.Text = "";
            txtamount.Text = "";
            txtprice.Text = "";
            txtdetail.Text = "";
            DropDownList1.SelectedIndex = 0;

            txtname.Enabled = false;
            txtamount.Enabled = false;
            txtprice.Enabled = false;
            txtdetail.Enabled = false;
            DropDownList1.Enabled = false;
            FileUpload1.Enabled = false;
        }
    }
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                // Save the uploaded image file to the ImgHerb folder in the project
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string filePath = Server.MapPath("~/ImgHerb/") + fileName;
                FileUpload1.SaveAs(filePath);

                // Set the src attribute of the <img> tag to display the uploaded image
                uploaded1.ImageUrl = ResolveUrl("~/ImgHerb/" + fileName);

            }
            catch (Exception ex)
            {
                // Handle errors that occur during upload
                lbleror.Text = "Error: " + ex.Message;
            }
        }
    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtserch.Text);
        string img = uploaded1.ImageUrl;
        string select = DropDownList1.SelectedValue.ToString();
        lbleror.Text = ConnectionClass.Updateproduct(id, txtname.Text, Convert.ToDouble(txtprice.Text), txtdetail.Text, select, Convert.ToInt32(txtamount.Text), img);
    }
}