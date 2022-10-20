using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;

namespace Final_Project.DAL
{
    public static class CategoryDB
    {
        public static List<Category> GetListRecord()
        {
            List<Category> listCategory = new List<Category>();
            Category category;
            using (SqlConnection conn = UtillityDB.ConnectDB())
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Categories", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        category = new Category();
                        category.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                        category.CategoryName = sqlReader["CategoryName"].ToString();
                        listCategory.Add(category);

                    }

                }

                else
                {
                    listCategory = null;
                }

            }
            return listCategory;

        }
        public static void SearchRecord(int Id)
        {
            Category category = new Category();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT* FROM Category " +
                                    "WHERE CategoryId = @CategoryId";
            cmdSelect.Parameters.AddWithValue("@CategoryId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                category.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                category.CategoryName = sqlReader["CategoryName"].ToString();

            }
            else
            {
                category = null;
            }
        }
        public static List<Category> SearchRecord(string name)
        {
            List<Category> listCategory = new List<Category>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Category" +
                                    "WHERE CategoryName = @CategoryName ";
            cmdSelect.Parameters.AddWithValue("@CategoryName", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Category category;
            while (sqlReader.Read())
            {
                category = new Category();
                category.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                category.CategoryName = sqlReader["CategoryName"].ToString();
                listCategory.Add(category);
            }
            return listCategory;
        }
        public static void UpdateRecord(Category category)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Category " +
                                    "SET    CategoryId = @CategoryId," +
                                    "       CategoryName = @CategoryName," +
                                    "WHERE  CategoryId = @CategoryId";
            cmdUpdate.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            cmdUpdate.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int categoryId)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Category " +
                                    "WHERE CategoryId= @CategoryId";
            cmdDelete.Parameters.AddWithValue("@CategoryId", categoryId);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}
