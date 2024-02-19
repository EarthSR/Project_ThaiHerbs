using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for typeofuser
/// </summary>
public class typeofuser
{
    public int Id { get; set; }
    public string Usertype { get; set; }
    public typeofuser(int id, string usertype)
    {
        Id = id;
        Usertype = usertype;
    }
    public typeofuser(string usertype) 
    {
        Usertype = usertype;
    }
}