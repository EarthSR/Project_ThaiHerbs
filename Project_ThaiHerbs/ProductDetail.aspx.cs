﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["productId"] != null)
            {
                int productId;
                if (int.TryParse(Request.QueryString["productId"], out productId))
                {
                    Session["ProductId"] = productId;
                    FillPage(productId);
                }
            }
        }
    }

    private void FillPage(int pid)
    {
        ArrayList productList = ConnectionClass.getproid(pid);

        StringBuilder sb = new StringBuilder();
        sb.Append("<link rel='stylesheet' type='text/css' href='CSS/ProductDetail.css'/>");
        foreach (Product product in productList)
        {
            sb.Append(string.Format(@" 
            <div class='detail-image'>
                <img src='{0}' class='detail-img'/>
            </div>
            <div class='detail-image'>
                <h2>{1}</h2>
                <h3>{2}</h3>
                <a>{3} บาท</a>
                <br />
                <a>จำนวนทั้งหมด : {4} </a> 
                <br />
                <br />
               ",
                product.Image, product.Name, product.Pdetail, product.Price, product.Amount));
        }

        lblshow.Text = sb.ToString();
    }

   

    protected void minus_Click(object sender, EventArgs e)
    {
        int currentValue;
        if (int.TryParse(txtamount.Text, out currentValue))
        {
            if (currentValue > 1)
            {
                currentValue--;
                txtamount.Text = currentValue.ToString();
            }
        }
        else
        {
            lble.Text = "Please enter a valid quantity.";
        }
    }

    protected void plus_Click(object sender, EventArgs e)
    {
        int currentValue;
        if (int.TryParse(txtamount.Text, out currentValue))
        {
            currentValue++;
            txtamount.Text = currentValue.ToString();
        }
        else
        {
            lble.Text = "Please enter a valid quantity.";
        }
    }

    public static int GetAvailableQuantity(int productId)
    {
        int availableQuantity = ConnectionClass.getprobyid(productId);
        return availableQuantity;
    }

    public static void UpdateAvailableQuantity(int productId, int newQuantity)
    {
        ConnectionClass.UpdateAvailableQuantity(productId, newQuantity);
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        int productId;
        int.TryParse(Request.QueryString["productId"], out productId);
        if (Session["userid"] != null)
        {
            int userid = (int)Session["userid"];
            bool isDuplicate = ConnectionClass.CheckDuplicateProductInCart(productId, userid);
            if (isDuplicate)
            {
                lble.Text = "This product is already in your cart.";
            }
            else
            {
                Product product = ConnectionClass.GetProductById(productId);
                if (product != null)
                {
                    string resultMessage = ConnectionClass.InsertCart(productId, product.Price, userid);
                    if (resultMessage == "Cart inserted successfully.")
                    {
                        // Provide a confirmation message
                        lble.Text = "Product added to cart successfully!";
                    }
                    else
                    {
                        // Handle insertion failure
                        lble.Text = "Failed to add product to cart. Please try again later.";
                    }
                }
                else
                {
                    // Handle product not found
                    lble.Text = "Product not found. Please select a valid product.";
                }
            }
            // Redirect to the same page after processing

            Response.Redirect(Request.RawUrl);
        }
        else
        {
            // Redirect to login page if user is not logged in
            Response.Redirect("~/Account/Login.aspx");
        }
    }

}