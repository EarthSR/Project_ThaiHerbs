using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;

/// <summary>
/// Summary description for Connection
/// </summary>
public class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;
    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebCSCPCConnectionString"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    public static User LoginUser(string username, string password)
    {
        User user = null;
        String query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        command.CommandText = query;
        try
        {
            conn.Open();
            int amoutofusers = (int)command.ExecuteScalar();
            if (amoutofusers == 1)
            {
                query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                string dbpassword = command.ExecuteScalar().ToString();
                if (dbpassword == password)
                {
                    query = string.Format("SELECT email, user_type FROM users WHERE username = '{0}'", username);
                    command.CommandText = query;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string usertype = reader.GetString(1);
                        DateTime brithday = reader.GetDateTime(2);
                        string phone = reader.GetString(3);
                        string address = reader.GetString(4);
                        string fristname = reader.GetString(5);
                        string lastname = reader.GetString(6);
                        user = new User(username, password, email, usertype, brithday, phone, address, fristname, lastname);
                    }

                    return user;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }
        finally
        {
            conn.Close();

        }


    }

    public static int validuser(string username)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        command.CommandText = query;
        try
        {
            conn.Open();
            int amountofusers = (int)command.ExecuteScalar();
            if (amountofusers > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        finally
        {
            conn.Close();
        }

    }

    public static string Registeruser(User user)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", user.UserName);
        command.CommandText = query;
        try
        {
            conn.Open();
            int amountOfusers = (int)command.ExecuteScalar();
            if (amountOfusers < 1)
            {
                query = "INSERT INTO users (typeofuser_fk, username, password, email, birthday) VALUES (@typeofuser, @username, @password, @email, @birthday)";
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@username", user.UserName));
                command.Parameters.Add(new SqlParameter("@password", user.Password));
                command.Parameters.Add(new SqlParameter("@type", user.UserType));
                command.Parameters.Add(new SqlParameter("@email", user.Email));

                command.ExecuteNonQuery();
                return "register user success!!!";
            }
            else
            {
                return "has alrady user!!!";
            }
        }
        finally
        {
            conn.Close();
        }
    }

}