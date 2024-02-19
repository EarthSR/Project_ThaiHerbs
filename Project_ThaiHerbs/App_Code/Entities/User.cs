using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public int IdUsers { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int UserType { get; set; }
    public DateTime Birthday { get; set; } 
    public string Phone { get; set; } 
    public string Address { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 

    public User(int idUsers, string userName, string password, string email, int userType, DateTime birthday, string phone, string address, string firstName, string lastName)
    {
        IdUsers = idUsers;
        UserName = userName;
        Password = password;
        Email = email;
        UserType = userType;
        Birthday = birthday;
        Phone = phone;
        Address = address;
        FirstName = firstName;
        LastName = lastName;
    }

    public User(string userName, string password, string email, int userType, DateTime birthday, string phone, string address, string firstName, string lastName)
    {
        UserName = userName;
        Password = password;
        Email = email;
        UserType = userType;
        Birthday = birthday;
        Phone = phone;
        Address = address;
        FirstName = firstName;
        LastName = lastName;
    }

    public User(string username, string password, string email, string usertype, DateTime birthday)
    {
        UserName = username;
        Password = password;
        Email = email;
        UserType = usertype;
        Birthday = birthday;
    }
}