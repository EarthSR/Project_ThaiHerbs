using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Pdetail { get; set; }
    public string Type { get; set; }
    public int Amount { get; set; }
    public string Image { get; set; }
    public Product(int id, string name, double price, string pdetail, string type, int amount, string image)
    {
        Id = id;
        Name = name;
        Price = price;
        Pdetail = pdetail;
        Type = type;
        Amount = amount;
        Image = image;
    }
    public Product(string name, double price, string pdetail, string type, int amount, string image)
    {
        Name = name;
        Price = price;
        Pdetail = pdetail;
        Type = type;
        Amount = amount;
        Image = image;
    }

    public Product(string name, double price, string pdetail, string type)
    {
        Name = name;
        Price = price;
        Pdetail = pdetail;
        Type = type;
    }
}