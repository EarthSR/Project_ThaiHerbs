using System;
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
    public string TrackingId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string DeliveryName { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public string TrackingID { get; set; }
    public string OrderStatus { get; set; }

    public Delivery(int deliveryId, int paymentId, string trackingId, DateTime deliveryDate, string deliveryName,string productname,string productimage,string trackingid,string status)
    {
        DeliveryId = deliveryId;
        PaymentId = paymentId;
        TrackingId = trackingId;
        DeliveryDate = deliveryDate;
        DeliveryName = deliveryName;
        ProductName = productname;
        ProductImage = productimage;
        TrackingID = trackingid;
        OrderStatus = status;

    }
    public Delivery(string trackingId, DateTime deliveryDate,string productname, string productimage, string trackingid, string status,string deliveryName)
    {
        TrackingId = trackingId;
        DeliveryDate = deliveryDate;
        DeliveryName = deliveryName;
        ProductName = productname;
        ProductImage = productimage;
        TrackingID = trackingid;
        OrderStatus = status;
    }
    public Delivery(string productname,string productimage,string trackingId,string status)
    {
        TrackingId = trackingId;
        DeliveryDate = deliveryDate;
        DeliveryName = deliveryName;
        ProductName = productname;
        ProductImage = productimage;
        TrackingID = trackingid;
        OrderStatus = status;
    }

}
