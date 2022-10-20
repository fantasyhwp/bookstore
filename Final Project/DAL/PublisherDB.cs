using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;

namespace Final_Project.DAL
{
    public static class PublisherDB
    {
        public static List<Publisher> GetListRecord()
        {
            List<Publisher> listPublisher = new List<Publisher>();
            Publisher publisher;
            using (SqlConnection conn = UtillityDB.ConnectDB())
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Publishers", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        publisher = new Publisher();
                        publisher.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                        publisher.PublisherName = sqlReader["PublisherName"].ToString();
                        listPublisher.Add(publisher);

                    }

                }

                else
                {
                    listPublisher = null;
                }

            }
            return listPublisher;

        }
        public static void SearchRecord(int Id)
        {
            Publisher publisher = new Publisher();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT* FROM Publishers " +
                                    "WHERE PublisherId = @PublisherId";
            cmdSelect.Parameters.AddWithValue("@PublisherId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                publisher.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                publisher.PublisherName = sqlReader["PublisherName"].ToString();

            }
            else
            {
                publisher = null;
            }
        }
        public static List<Publisher> SearchRecord(string name)
        {
            List<Publisher> listPublisher = new List<Publisher>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM PublisherS" +
                                    "WHERE PublisherName = @PublisherName ";
            cmdSelect.Parameters.AddWithValue("@PublisherName", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Publisher publisher;
            while (sqlReader.Read())
            {
                publisher = new Publisher();
                publisher.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                publisher.PublisherName = sqlReader["PublisherName"].ToString();
                listPublisher.Add(publisher);
            }
            return listPublisher;
        }
        public static void UpdateRecord(Publisher publisher)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Publishers " +
                                    "SET    PublisherId = @PublisherId," +
                                    "       PublisherName = @PublisherName," +
                                    "WHERE  PublisherId = @PublisherId";
            cmdUpdate.Parameters.AddWithValue("@PublisherId", publisher.PublisherId);
            cmdUpdate.Parameters.AddWithValue("@SupplierName", publisher.PublisherName);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int PublisherId)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Publishers " +
                                    "WHERE PublisherId= @PublisherId";
            cmdDelete.Parameters.AddWithValue("@PublisherId", PublisherId);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}
