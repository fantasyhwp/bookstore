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
                        book.BookTitel = sqlReader["BookTitle"].ToString();
                        book.Isbn = sqlReader["Isbn"].ToString();
                        book.Qoh = sqlReader["QOH"].ToString();
                        book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);
                        book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                        book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                        book.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
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
                book = new Book();
                book.BookTitel = sqlReader["BookTitle"].ToString();
                book.Isbn = sqlReader["Isbn"].ToString();
                book.Qoh = sqlReader["QOH"].ToString();
                book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);
                book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                book.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);

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
                book.BookTitel = sqlReader["BookTitle"].ToString();
                book.Isbn = sqlReader["Isbn"].ToString();
                book.Qoh = sqlReader["QOH"].ToString();
                book.UnitPrice = Convert.ToInt32(sqlReader["UnitPrice"]);
                book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                book.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
                listStudent.Add(book);
            }
            return listStudent;
        }
        public static void UpdateRecord(Book book)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Books " +
                                    "SET    Isbn = @Isbn," +
                                    "       BookTitel = @BookTitel," +
                                    "       QOH = @QOH," +
                                    "       UnitPrice = @UnitPrice " +
                                    "       CategoryId = @CategoryId " +
                                    "       PublisherId = @PublisherId " +
                                    "       AuthorId = @AuthorId " +
                                    "WHERE  Isbn = @Isbn";
            cmdUpdate.Parameters.AddWithValue("@Isbn", book.Isbn);
            cmdUpdate.Parameters.AddWithValue("@BookTitel", book.BookTitel);
            cmdUpdate.Parameters.AddWithValue("@QOH", book.Qoh);
            cmdUpdate.Parameters.AddWithValue("@CategoryId", book.CategoryId);
            cmdUpdate.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdUpdate.Parameters.AddWithValue("@PublisherId", book.PublisherId);
            cmdUpdate.Parameters.AddWithValue("@AuthorId", book.AuthorId);
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
