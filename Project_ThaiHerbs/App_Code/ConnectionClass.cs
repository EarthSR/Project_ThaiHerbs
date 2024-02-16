﻿using System.Configuration;
using System.Data.SqlClient;
using System;

public class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    public static User LoginUser(string username, string password)
    {
        User user = null;
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}' AND password = '{1}'", username, password);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();
            if (amountOfUsers == 1)
            {
                query = string.Format("SELECT email, typeofuser, birthday, phone, address, fristname, lastname FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string email = reader.GetString(0);
                    string userType = reader.GetString(1);
                    DateTime birthday = reader.GetDateTime(2);
                    string phone = reader.IsDBNull(3) ? null : reader.GetString(3);
                    string address = reader.IsDBNull(4) ? null : reader.GetString(4);
                    string firstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                    string lastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                    user = new User(username, password, email, userType, birthday, phone, address, firstName, lastName);
                }
                reader.Close();
            }
            return user;
        }
        finally
        {
            conn.Close();
        }
    }

    public static int ValidUser(string username)
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

    public static string RegisterUser(User user)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", user.UserName);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();
            if (amountOfUsers < 1)
            {
                query = "INSERT INTO users (typeofuser, username, password, email, birthday) VALUES (@typeofuser, @username, @password, @email, @birthday)";
                command.CommandText = query;

                // Clear existing parameters
                command.Parameters.Clear();

                // Add parameters
                command.Parameters.AddWithValue("@typeofuser", user.UserType);
                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@birthday", user.Birthday);

                command.ExecuteNonQuery();
                return "register user success!!!";
            }
            else
            {
                return "user already exists!!!";
            }
        }
        finally
        {
            conn.Close();
        }
    }
}
