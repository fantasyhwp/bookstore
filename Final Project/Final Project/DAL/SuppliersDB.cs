using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;

namespace Final_Project.DAL
{
    public static class SuppliersDB
    {
        public static List<Suppliers> GetListRecord()
        {
            List<Suppliers> listSuppliers = new List<Suppliers>();
            Suppliers suppliers;
            using (SqlConnection conn = UtillityDB.ConnectDB())
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Suppliers", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        suppliers = new Suppliers();
                        suppliers.SupplierId = Convert.ToInt32(sqlReader["SupplierId"]);
                        suppliers.SupplierName = sqlReader["SupplierName"].ToString();
                        listSuppliers.Add(suppliers);

                    }

                }

                else
                {
                    listSuppliers = null;
                }

            }
            return listSuppliers;

        }
        public static void SearchRecord(int Id)
        {
            Suppliers suppliers = new Suppliers();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT* FROM Suppliers " +
                                    "WHERE SupplierId = @SupplierId";
            cmdSelect.Parameters.AddWithValue("@SupplierId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read())
            {
                suppliers.SupplierId = Convert.ToInt32(sqlReader["SupplierId"]);
                suppliers.SupplierName = sqlReader["SupplierName"].ToString();

            }
            else
            {
                suppliers = null;
            }
        }
        public static List<Suppliers> SearchRecord(string name)
        {
            List<Suppliers> listSuppliers = new List<Suppliers>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Suppliers" +
                                    "WHERE SupplierName = @SupplierName ";
            cmdSelect.Parameters.AddWithValue("@SupplierName", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Suppliers suppliers;
            while (sqlReader.Read())
            {
                suppliers = new Suppliers();
                suppliers.SupplierId = Convert.ToInt32(sqlReader["SupplierId"]);
                suppliers.SupplierName = sqlReader["SupplierName"].ToString();
                listSuppliers.Add(suppliers);
            }
            return listSuppliers;
        }
        public static void UpdateRecord(Suppliers suppliers)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Suppliers " +
                                    "SET    SupplierId = @SupplierId," +
                                    "       SupplierName = @SupplierName," +
                                    "WHERE  SupplierId = @SupplierId";
            cmdUpdate.Parameters.AddWithValue("@SupplierId", suppliers.SupplierId);
            cmdUpdate.Parameters.AddWithValue("@SupplierName", suppliers.SupplierName);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int SupplierId)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Suppliers " +
                                    "WHERE SupplierId= @SupplierId";
            cmdDelete.Parameters.AddWithValue("@SupplierId", SupplierId);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}
