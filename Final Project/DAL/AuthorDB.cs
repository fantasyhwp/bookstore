using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;

namespace Final_Project.DAL
{
    public static class AuthorDB
    {
        public static List<Author> GetListRecord()
        {
            List<Author> listAuthor = new List<Author>();
            Author author;
            using (SqlConnection conn = UtillityDB.ConnectDB())
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Authors", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        author = new Author();
                        author.AuthorId= Convert.ToInt32(sqlReader["AuthorId"]);
                        author.AuthorName = sqlReader["AuthorName"].ToString();
                        listAuthor.Add(author);

                    }

                }

                else
                {
                    listAuthor = null;
                }

            }
            return listAuthor;

        }
        public static void SearchRecord(int Id)
        {
            Author author = new Author();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT* FROM Authors " +
                                    "WHERE AuthorId = @AuthorId";
            cmdSelect.Parameters.AddWithValue("@AuthorId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                author.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
                author.AuthorName = sqlReader["AuthorName"].ToString();
                
            }
            else
            {
                author = null;
            }


        }
        public static List<Author> SearchRecord(string name)
        {
            List<Author> listAuthor = new List<Author>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Authors" +
                                    "WHERE AuthorName = @AuthorName ";
            cmdSelect.Parameters.AddWithValue("@AuthorName", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Author author;
            while (sqlReader.Read())
            {
                author = new Author();
                author.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
                author.AuthorName = sqlReader["AuthorName"].ToString();
                listAuthor.Add(author);
            }
            return listAuthor;
        }
        public static void UpdateRecord(Author author)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Authors " +
                                    "SET    AuthorId = @AuthorId," +
                                    "       AuthorName = @AuthorName," +
                                    "WHERE  AuthorId = @AuthorId";
            cmdUpdate.Parameters.AddWithValue("@AuthorId", author.AuthorId);
            cmdUpdate.Parameters.AddWithValue("@AuthorName", author.AuthorName);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int authorId)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Authors " +
                                    "WHERE AuthorId= @AuthorId";
            cmdDelete.Parameters.AddWithValue("@AuthorId", authorId);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}
