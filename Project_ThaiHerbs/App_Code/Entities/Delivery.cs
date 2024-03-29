﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Delivery
/// </summary>
public class Delivery
{
    public int DeliveryId { get; set; }
    public int PaymentId { get; set; }
    public int TrackingId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string DeliveryName { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public string OrderStatus { get; set; }
    public int Orderdetailid { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateTime Daterecevied{ get; set; }

    public Delivery(int deliveryId, int paymentId, int trackingId, DateTime deliveryDate, string deliveryName,string productname,string productimage,int trackingid,string status)
    {
        DeliveryId = deliveryId;
        PaymentId = paymentId;
        TrackingId = trackingId;
        DeliveryDate = deliveryDate;
        DeliveryName = deliveryName;
        ProductName = productname;
        ProductImage = productimage;
        TrackingId = trackingid;
        OrderStatus = status;

    }
    public Delivery(int trackingId, DateTime deliveryDate,string productname, string productimage, int trackingid, string status,string deliveryName)
    {
        TrackingId = trackingId;
        DeliveryDate = deliveryDate;
        DeliveryName = deliveryName;
        ProductName = productname;
        ProductImage = productimage;
        TrackingId = trackingid;
        OrderStatus = status;
    }
    public Delivery(string productname,string productimage,int trackingId,string status,string deliveryName,int orderdetailid_fk)
    {
        Orderdetailid = orderdetailid_fk;
        TrackingId = trackingId;
        ProductName = productname;
        ProductImage = productimage;
        OrderStatus = status;
        DeliveryName = deliveryName;
    }

    public Delivery(string productname, string productimage, int amount,double price,DateTime date)
    {
        Daterecevied = date;
        ProductName = productname;
        ProductImage = productimage;
        Amount = amount;
        Price = price;

    }

}
