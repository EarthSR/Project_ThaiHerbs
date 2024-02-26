using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class review
{
    public int Reviewid { get; set; }
    public int Productid { get; set; }
    public int Userid { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; }
    public int Score { get; set; }
    public string Username { get; set; }
    public review(int reviewid,int productid,int userid,DateTime date,string comment,int score)
    {
        Reviewid = reviewid;
        Productid = productid;
        Userid = userid;
        Date = date;
        Comment = comment;
        Score = score;
    }
    public review( int productid, int userid, DateTime date, string comment, int score,string username)
    {
        Productid = productid;
        Userid = userid;
        Date = date;
        Comment = comment;
        Score = score;
        Username = username;
    }

}