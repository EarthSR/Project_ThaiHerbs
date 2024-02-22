using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;

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
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}' AND [password] = '{1}'", username, password);
        command.CommandText = query;
        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();
            if (amountOfUsers == 1)
            {
                command.Parameters.Clear();

                query = string.Format("SELECT userid, email, typeofuser_fk, birthday, phone, address, firstname, lastname FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string email = reader.GetString(1);
                    string typeofuser_fk = reader.GetString(2); 
                    DateTime birthday = reader.GetDateTime(3);
                    string phone = reader.IsDBNull(4) ? null : reader.GetString(4);
                    string address = reader.IsDBNull(5) ? null : reader.GetString(5);
                    string firstName = reader.IsDBNull(6) ? null : reader.GetString(6);
                    string lastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                    user = new User(userId, username, password, email, typeofuser_fk.ToString(), birthday, phone, address, firstName, lastName);
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


    public static string CheckTypeOfUser(int userId)
    {
        string result = "";

        string query = "SELECT tu.typeofuser FROM users u INNER JOIN typeofuser tu ON u.typeofuser_fk = tu.typeofuserid WHERE u.userid = @UserId;";
        command.CommandText = query;
        command.Parameters.AddWithValue("@UserId", userId);

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                result = reader["typeofuser"].ToString();
            }
        }
        finally
        {
            conn.Close();
        }

        return result;
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
                query = "INSERT INTO users (typeofuser_fk, username, password, email, birthday) VALUES (@typeofuser, @username, @password, @email, @birthday)";
                command.CommandText = query;

                
                command.Parameters.Clear();
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
    public static ArrayList GetproductByType(string Producttype)
    {
        ArrayList list = new ArrayList();
        string querry = string.Format("SELECT * From product WHERE ptype LIKE '{0}'", Producttype);

        try
        {
            conn.Open();
            command.CommandText = querry;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string detail = reader.GetString(3);
                string type = reader.GetString(4);
                int amount = reader.GetInt32(5);
                string image = reader.GetString(6);

                Product product = new Product(id,name, price, detail, type, amount, image);

                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static Product GetProductById(int id)
    {
        Product product = null;
        string query = string.Format("SELECT * From product WHERE productid = '{0}'", id);
        command.CommandText = query;
        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                float price = reader.GetFloat(1);
                string detail = reader.GetString(2);
                string type = reader.GetString(3);
                int amount = reader.GetInt32(4);
                string image = reader.GetString(5);

                product = new Product(name, price, detail, type, amount, image);

            }
        }
        finally
        {
            conn.Close();
        }
        return product;
    }

    public static ArrayList Searchbar(string searchs)
    {
        ArrayList list = new ArrayList();
        string query = "SELECT * From product WHERE pname LIKE @search OR pdetail LIKE @search";
        command.CommandText = query;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@search", "%" + searchs + "%");

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string detail = reader.GetString(3);
                string type = reader.GetString(4);
                int amount = reader.GetInt32(5);
                string image = reader.GetString(6);

                Product product = new Product(id, name, price, detail, type, amount, image);

                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static ArrayList getproid(int proid)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * From product WHERE productid = '{0}'", proid);
        command.CommandText = query;
        command.Parameters.Clear();

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string detail = reader.GetString(3);
                string type = reader.GetString(4);
                int amount = reader.GetInt32(5);
                string image = reader.GetString(6);

                Product product = new Product(id, name, price, detail, type, amount, image);

                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }


}


