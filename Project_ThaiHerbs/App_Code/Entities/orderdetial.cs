using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for orderdetial
/// </summary>
public class orderdetial
{
    public int Orderdetailid { get; set; }
    public int Productid { get; set; }
    public double Priceofproduct { get; set; }
    public string Statusoforder { get; set; }
    public int Userid { get; set; }
    public string Image { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }

    public orderdetial(int orderdetailid, int productid, double priceofproduct, string statusoforder, int userid, string image, int amount, string name)
    {
        Orderdetailid = orderdetailid;
        Productid = productid;
        Priceofproduct = priceofproduct;
        Statusoforder = statusoforder;
        Userid = userid;
        Image = image;
        Amount = amount;
        Name = name;
    }
    public orderdetial(int orderdetailid, int productid, double priceofproduct, int userid, string image, int amount, string name)
    {
        Orderdetailid = orderdetailid;
        Productid = productid;
        Priceofproduct = priceofproduct;
        Userid = userid;
        Image = image;
        Amount = amount;
        Name = name;
    }

}