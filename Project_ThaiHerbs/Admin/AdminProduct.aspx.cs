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

public partial class AdminProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        string select = DropDownList1.SelectedValue;
        string imagePath = uploaded.ImageUrl; // Get the image file path
        lblerror.Text = ConnectionClass.InsertProduct(txtname.Text, Convert.ToDouble(txtprice.Text),txtdetail.Text,select, Convert.ToInt32(txtamount.Text), imagePath);
        // Handle the result if necessary
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string select = DropDownList1.SelectedValue;
        if (select == "กรุณาเลือกประเภทสินค้า")
        {
            DropDownList1 = null;
        }
    }

    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {
            try
            {
                // Save the uploaded image file to the ImgHerb folder in the project
                string fileName = Path.GetFileName(FileUpload2.FileName);
                string filePath = Server.MapPath("~/ImgHerb/") + fileName;
                FileUpload2.SaveAs(filePath);

                // Set the src attribute of the <img> tag to display the uploaded image
                uploaded.ImageUrl = ResolveUrl("~/ImgHerb/" + fileName);
                
            }
            catch (Exception ex)
            {
                // Handle errors that occur during upload
                lblerror.Text = "Error: " + ex.Message;
            }
        }
    }


}
