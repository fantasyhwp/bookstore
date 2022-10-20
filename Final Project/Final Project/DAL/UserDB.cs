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
    }
}
