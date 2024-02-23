using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for orderdetial
/// </summary>
public class orderdetial
{
    public int Orderdetailid;
    public int Productid;
    public double Priceofproduct;
    public string Statusoforder;
    public int Userid;

    public orderdetial(int orederdetailid,int productid,double priceofproduct,string statusoforder,int userid)
    {
        Orderdetailid = orederdetailid;
        Productid = productid;
        Priceofproduct = priceofproduct;
        Statusoforder = statusoforder;
        Userid = userid;
    }
}