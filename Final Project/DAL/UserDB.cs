using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Final_Project.BLL;

namespace Final_Project.DAL
{
    public class UserDB
    {
        public static bool LogIn(int userid, string password)
        {

            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = conn;
            cmdSelect.CommandText = "SELECT * FROM Users " + "WHERE UserId=@UserId and Password=@Password";
            cmdSelect.Parameters.AddWithValue("@UserId", userid);
            cmdSelect.Parameters.AddWithValue("@Password", password);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                
                return true;
            }
            
            return false;
        }
        public static List<User> ListAllRecords()
        {
            List<User> listUser = new List<User>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM UserS ";
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            User user;
            while (sqlReader.Read())
            {
                user = new User();
                user.UserId = Convert.ToInt32(sqlReader["UserId"]);
                user.Password = sqlReader["Password"].ToString();
                user.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                listUser.Add(user);

            }
            return listUser;

        }

        public static void UpdateRecord(User user)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                    "SET UserId = @UserId," +
                                    "Password = @Password," +
                                    "EmployeeId = @EmployeeId," +
                                    "WHERE UserId = @UserId";
            cmdUpdate.Parameters.AddWithValue("@UserId", user.UserId);
            cmdUpdate.Parameters.AddWithValue("@Password", user.Password);
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);;
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteRecord(int Id)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM User " +
                                    "WHERE UserId = @UserId";
            cmdDelete.Parameters.AddWithValue("@UserId", Id);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }

        public static void SaveRecord(User user)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "INSERT INTO Users(UserId,Password,EmployeeId) " +
                                    " VALUES (@UserId,@Password,@EmployeeId)";
            cmdInsert.Parameters.AddWithValue("@UserId", user.UserId);
            cmdInsert.Parameters.AddWithValue("@Password", user.Password);
            cmdInsert.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }

        public static User SearchRecord(int Id)
        {
            User user = new User();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Users " +
                                    "WHERE UserId = @UserId";
            cmdSelect.Parameters.AddWithValue("@UserId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                user.UserId = Convert.ToInt32(sqlReader["UserId"]);
                user.Password = sqlReader["Password"].ToString();
                user.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
            }
            else
            {
                user = null;
            }

            return user;
        }
    }
}
