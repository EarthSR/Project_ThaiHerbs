using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ComponentModel;

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

        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand())
        {
            string query = "SELECT COUNT(*) FROM users WHERE username = @username AND [password] = @password";
            command.CommandText = query;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Connection = conn;

            try
            {
                conn.Open();
                int amountOfUsers = (int)command.ExecuteScalar();
                if (amountOfUsers == 1)
                {
                    command.Parameters.Clear();

                    query = "SELECT userid, email, typeofuser_fk, birthday, phone, address, firstname, lastname, gender FROM users WHERE username = @username";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string typeofuser_fk = reader.GetString(2);
                        DateTime? birthday = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        string phone = reader.IsDBNull(4) ? null : reader.GetString(4);
                        string address = reader.IsDBNull(5) ? null : reader.GetString(5);
                        string firstName = reader.IsDBNull(6) ? null : reader.GetString(6);
                        string lastName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        string gender = reader.IsDBNull(8) ? null : reader.GetString(8);
                        user = new User(userId, username, password, email, typeofuser_fk, birthday, phone, address, firstName, lastName, gender);
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
    }





    public static string CheckTypeOfUser(int userId)
    {
        string result = "";

        string query = "SELECT tu.typeofuser FROM users u INNER JOIN typeofuser tu ON u.typeofuser_fk = tu.typeofuserid WHERE u.userid = @UserId;";
        command.Parameters.Clear();
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
                query = "INSERT INTO users (typeofuser_fk, username, password, email, gender) VALUES (@typeofuser, @username, @password, @email, @gender)";
                command.CommandText = query;


                command.Parameters.Clear();
                command.Parameters.AddWithValue("@typeofuser", user.UserType);
                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@gender", user.Gender);

                command.ExecuteNonQuery();
                return "register users success!!!";
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
        string querry = "SELECT * FROM product WHERE ptype LIKE @ProductType";
        command.CommandText = querry;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@ProductType", "%" + Producttype + "%");

        try
        {
            conn.Open();
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


    public static Product GetProductById(int id)
    {
        Product product = null;
        string query = "SELECT * FROM product WHERE productid = @ProductId";

        command.CommandText = query;
        command.Parameters.Clear();

        command.Parameters.AddWithValue("@ProductId", id);

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int productId = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string detail = reader.GetString(3);
                string type = reader.GetString(4);
                int amount = reader.GetInt32(5);
                string image = reader.GetString(6);

                product = new Product(productId, name, price, detail, type, amount, image);
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

    public static string InsertCart(int productId, double priceOfProduct, int userId, int amount)
    {
        string resultMessage = null;

        string query = "INSERT INTO cart (productid, price, userid,amount) " +
                       "VALUES (@ProductId, @PriceOfProduct, @UserId,@amount)";

        command.CommandText = query;
        command.Parameters.Clear();

        command.Parameters.AddWithValue("@ProductId", productId);
        command.Parameters.AddWithValue("@PriceOfProduct", priceOfProduct);
        command.Parameters.AddWithValue("@UserId", userId);
        command.Parameters.AddWithValue("@amount", amount);

        try
        {
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                resultMessage = "Cart inserted successfully.";
            }
            else
            {
                resultMessage = "Failed to insert cart.";
            }
        }
        catch (Exception ex)
        {
            resultMessage = "Error: " + ex.Message;
        }
        finally
        {
            conn.Close();
        }

        return resultMessage;
    }


    public static bool CheckDuplicateProductInCart(int productId, int userId)
    {
        bool isDuplicate = false;

        {
            string query = "SELECT COUNT(*) FROM cart WHERE productid = @ProductId AND userid = @UserId";
            command.CommandText = query;
            {
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    conn.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicate = true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        return isDuplicate;
    }

    public static ArrayList GetProductsByUserId(int userId)
    {
        ArrayList productList = new ArrayList();
        string query = "SELECT p.productid,p.pname,p.pprice,p.pdetail,p.ptype,c.amount,p.pimage FROM product p " +
                       "INNER JOIN cart c ON p.productid = c.productid " +
                       "WHERE c.userid = @UserId";

        command.CommandText = query;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@UserId", userId);

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int productId = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string detail = reader.GetString(3);
                string type = reader.GetString(4);
                int amount = reader.GetInt32(5);
                string image = reader.GetString(6);

                Product product = new Product(productId, name, price, detail, type, amount, image);
                productList.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return productList;
    }

    public static string DeleteCartItem(int userid)
    {
        string resultMessage = null;

        string query = "DELETE FROM cart WHERE userid = @userid ";

        command.CommandText = query;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@userid", userid);
        try
        {
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                resultMessage = "Cart item deleted successfully.";
            }
            else
            {
                resultMessage = "Failed to delete cart item.";
            }
        }
        catch (Exception ex)
        {
            resultMessage = "Error: " + ex.Message;
        }
        finally
        {
            conn.Close();
        }

        return resultMessage;
    }

    public static int getprobyid(int proid)
    {
        int proamount = 0;
        string query = string.Format("SELECT pamount From product WHERE productid = '{0}'", proid);
        command.CommandText = query;
        command.Parameters.Clear();

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int amount = reader.GetInt32(0);
                proamount = amount; // กำหนดค่า proamount เมื่ออ่านข้อมูลสำเร็จ
            }
        }
        finally
        {
            conn.Close();
        }

        return proamount; // คืนค่า proamount ที่ถูกต้อง
    }

    public static void UpdateAvailableQuantity(int productId, int amount)
    {
        try
        {
            {
                conn.Open();
                string updateQuery = "UPDATE product SET pamount = pamount - @Amount WHERE productid = @ProductId";
                command.CommandText = updateQuery;
                {
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Product not found or quantity not updated.");
                    }
                    else
                    {
                        Console.WriteLine("Quantity updated successfully.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating quantity: " + ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    public static void ClearCart(int userId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string deleteQuery = "DELETE FROM cart WHERE userid = @UserId";

            using (SqlCommand command = new SqlCommand(deleteQuery, conn))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Cart items deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No cart items found for the user.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting cart items: " + ex.Message);
                }
            }
        }
    }

}