using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;

namespace Final_Project.DAL
{
    public static class BookDB
    {
        public static List<Book> GetListRecord()
        {
            List<Book> ListBook = new List<Book>();
            Book book;
            using (SqlConnection conn=UtillityDB.ConnectDB()){
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Books", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        book = new Book();
                        book.BookId = Convert.ToInt32(sqlReader["BookId"]);
                        book.Title = sqlReader["Title"].ToString();
                        book.Isbn= sqlReader["Isbn"].ToString();
                        book.YearPublished = Convert.ToInt32(sqlReader["YearPublished"]);
                        book.Supplier= sqlReader["Supplier"].ToString();
                        book.Author= sqlReader["Author"].ToString();
                        book.Category= sqlReader["Category"].ToString();
                        book.Qoh = Convert.ToInt32(sqlReader["Qoh"]);
                        book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);
                        ListBook.Add(book);
                    }
                }
                else
                {
                    ListBook = null;
                }             
            }
            return ListBook;
        }
        public static void SearchRecord(int Id)
        {
            Book book = new Book();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT* FROM Books " +
                                    "WHERE BookId = @BookId";
            cmdSelect.Parameters.AddWithValue("@BooksId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                book.BookId = Convert.ToInt32(sqlReader["BookId"]);
                book.Title = sqlReader["Title"].ToString();
                book.Isbn = sqlReader["Isbn"].ToString();
                book.YearPublished = Convert.ToInt32(sqlReader["YearPublished"]);
                book.Supplier = sqlReader["Supplier"].ToString();
                book.Author = sqlReader["Author"].ToString();
                book.Category = sqlReader["Category"].ToString();
                book.Qoh = Convert.ToInt32(sqlReader["Qoh"]);
                book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);

            }
            else
            {
                book = null;
            }


        }
        public static List<Book> SearchRecord(string name)
        {
            List<Book> listStudent = new List<Book>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Books" +
                                    "WHERE Author = @Author " +
                                    " Or Isbn = @LastName ";
            cmdSelect.Parameters.AddWithValue("@Author", name);
            cmdSelect.Parameters.AddWithValue("@Isbn", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Book book;
            while (sqlReader.Read())
            {
                book = new Book();
                book.BookId = Convert.ToInt32(sqlReader["BookId"]);
                book.Title = sqlReader["Title"].ToString();
                book.Isbn = sqlReader["Isbn"].ToString();
                book.YearPublished = Convert.ToInt32(sqlReader["YearPublished"]);
                book.Supplier = sqlReader["Supplier"].ToString();
                book.Author = sqlReader["Author"].ToString();
                book.Category = sqlReader["Category"].ToString();
                book.Qoh = Convert.ToInt32(sqlReader["Qoh"]);
                book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);
                listStudent.Add(book);
            }
            return listStudent;
        }
        public static void UpdateRecord(Book book)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Books " +
                                    "SET    BookId = @BookId," +
                                    "       Title = @Title," +
                                    "       Isbn = @Isbn," +
                                    "       YearPublished = @YearPublished " +
                                    "       Supplier = @Supplier " +
                                    "       Author = @Author " +
                                    "       Category = @Category " +
                                    "       Qoh = @Qoh " +
                                    "       UnitPrice = @UnitPrice " +
                                    "WHERE  BookId = @BookId";
            cmdUpdate.Parameters.AddWithValue("@BookId", book.BookId);
            cmdUpdate.Parameters.AddWithValue("@Title", book.Title);
            cmdUpdate.Parameters.AddWithValue("@Isbn", book.Isbn);
            cmdUpdate.Parameters.AddWithValue("@YearPublished", book.YearPublished);
            cmdUpdate.Parameters.AddWithValue("@Supplier", book.Supplier);
            cmdUpdate.Parameters.AddWithValue("@Author", book.Author);
            cmdUpdate.Parameters.AddWithValue("@Category", book.Category);
            cmdUpdate.Parameters.AddWithValue("@Qoh", book.Qoh);
            cmdUpdate.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int BookId)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Books " +
                                    "WHERE BookId= @BookId";
            cmdDelete.Parameters.AddWithValue("@BookId", BookId);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}
