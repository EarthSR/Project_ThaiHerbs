using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ComponentModel;
using System.Data;

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

                    query = "SELECT userid, email, typeofuser_fk, phone, address, firstname, lastname, gender FROM users WHERE username = @username";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string typeofuser_fk = reader.GetString(2);
                        string phone = reader.IsDBNull(3) ? null : reader.GetString(3);
                        string address = reader.IsDBNull(4) ? null : reader.GetString(4);
                        string firstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        string lastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                        string gender = reader.IsDBNull(7) ? null : reader.GetString(7);
                        user = new User(userId, username, password, email, typeofuser_fk ,phone, address, firstName, lastName, gender);
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

    public static List<Product> GetProductsByUserId(int userId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        List<Product> productList = new List<Product>();
        string query = "SELECT p.productid,p.pname,p.pprice,p.pdetail,p.ptype,c.amount,p.pimage FROM product p " +
                       "INNER JOIN cart c ON p.productid = c.productid " +
                       "WHERE c.userid = @UserId";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, conn))
            {
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
            }
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

    public static string Insertorderdetail(int productId, double priceOfProduct, int userId, int amount,string status)
    {
        string resultMessage = null;

        string query = "insert into orderdetail (productid_fk,priceofproduct,userid,amount,status) values (@productid,@price,@userid,@amount,@status)";

        command.CommandText = query;
        command.Parameters.Clear();

        command.Parameters.AddWithValue("@productid", productId);
        command.Parameters.AddWithValue("@price", priceOfProduct);
        command.Parameters.AddWithValue("@userid", userId);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@status", status);

        try
        {
            conn.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                resultMessage = "Orederd successfully.";
            }
            else
            {
                resultMessage = "Failed to insert.";
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

    public static List<orderdetial> GetOrderDetailById(int userids)
    {
        List<orderdetial> list = new List<orderdetial>();
        string query = "SELECT od.orderdetailid, od.productid_fk, od.priceofproduct, od.userid, od.amount, od.status, p.pimage, p.pname " +
                       "FROM orderdetail od " +
                       "JOIN product p ON od.productid_fk = p.productid " +
                       "WHERE od.userid = @userid AND od.status = 'Waiting for payment'";

        command.CommandText = query;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@userid", userids);

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderdetailid = reader.GetInt32(0);
                int productid = reader.GetInt32(1);
                double price = reader.GetDouble(2);
                int userid = reader.GetInt32(3);
                int amount = reader.GetInt32(4);
                string status = reader.GetString(5);
                string image = reader.GetString(6);
                string name = reader.GetString(7);
                orderdetial orderdetail = new orderdetial(orderdetailid, productid, price, status, userid, image, amount, name);

                list.Add(orderdetail);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static string UpdateUserData(int userId, string firstname, string lastname, string address, string phone, string email, string password, string gender)
    {
        string resultMessage = "";
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(@"UPDATE users
                                             SET
                                                 firstname = @FirstName,
                                                 lastname = @LastName,
                                                 address = @Address,
                                                 phone = @Phone,
                                                 email = @Email,
                                                 password = @Password,
                                                 gender = @Gender
                                             WHERE
                                                 userid = @UserId", conn);

            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Gender", gender); 
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                resultMessage = "Rows affected: " + rowsAffected;
            }
            catch (Exception ex)
            {
                resultMessage = "Error updating user data: " + ex.Message;
            }
        }
        return resultMessage;
    }



    public static void InsertOrder(int userId, int orderdetailid,double totalPrice, int totalAmount)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        string query = "INSERT INTO orders (userid_fk, orderdetailid_fk ,totalprice, totalamount, ordersdate) VALUES (@UserId, @orderdetailid,@TotalPrice, @TotalAmount, GETDATE())";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // กำหนดค่าพารามิเตอร์
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@orderdetailid", orderdetailid);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    // เปิดการเชื่อมต่อ
                    connection.Open();

                    // ประมวลผลคำสั่ง SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // หากมีการเพิ่มรายการสำเร็จ
                        Console.WriteLine("Order added successfully.");
                    }
                    else
                    {
                        // หากไม่สามารถเพิ่มรายการได้
                        Console.WriteLine("Failed to add order.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // จัดการข้อผิดพลาดที่เกิดขึ้น
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    public static void Insertpayment(int orderid, int userid, DateTime paymentdate, string typeofpayment)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        string query = "INSERT INTO payment (orderid_fk, userid_fk, paymentdate, typeofpayment) VALUES (@order, @userid, @paydate, @paytype)";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@order", orderid);
                    command.Parameters.AddWithValue("@paydate", paymentdate);
                    command.Parameters.AddWithValue("@paytype", typeofpayment);

                    // Open connection
                    connection.Open();

                    // Execute SQL command
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // If payment is inserted successfully
                        Console.WriteLine("Payment inserted successfully.");
                    }
                    else
                    {
                        // If payment insertion fails
                        Console.WriteLine("Failed to insert payment.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the error
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    public static string Updatestatus(string status,int userid,int orderid)
    {
        string resultMessage = "";
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(@"UPDATE orderdetail
                                             SET
                                                 status = @status
                                             WHERE
                                                 userid = @userid AND orderid_fk = @order", conn);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@order", orderid);
            command.Parameters.AddWithValue("@status", status);

            try
            {
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                resultMessage = "Rows affected: " + rowsAffected;
            }
            catch (Exception ex)
            {
                resultMessage = "Error updating user data: " + ex.Message;
            }
        }
        return resultMessage;
    }


    public static string Updateaddress(int userId, string address)
    {
        string resultMessage = "";
        string connectionString = ConfigurationManager.ConnectionStrings["dbWebThaiHerbs"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(@"UPDATE users
                                             SET
                                                 address = @Address
                                             WHERE
                                                 userid = @UserId", conn);

            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                resultMessage = "Rows affected: " + rowsAffected;
            }
            catch (Exception ex)
            {
                resultMessage = "Error updating user data: " + ex.Message;
            }
        }
        return resultMessage;
    }

    public static List<review> Getreview(int productid)
    {
        List<review> list = new List<review>();
        string query = "SELECT review.*, users.username FROM review JOIN users ON review.userid_fk = users.userid WHERE review.productid_fk = @proid;";

        command.CommandText = query;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@proid", productid);

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int productid_fk = reader.GetInt32(1);
                int userid_fk = reader.GetInt32(2);
                DateTime date = reader.GetDateTime(3);
                int score = reader.GetInt32(4);
                string comment = reader.GetString(5);
                string username = reader.GetString(6);
                review review = new review(productid_fk,userid_fk,date,comment,score,username);

                list.Add(review);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }
}