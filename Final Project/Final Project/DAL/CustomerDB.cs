using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;


namespace Final_Project.DAL
{
    public static class CustomerDB
    {
        public static List<Customer> GetListRecord()
        {
            List<Customer> listCustomer = new List<Customer>();
            Customer aCustomer;
            using (SqlConnection conn = UtillityDB.ConnectDB())
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Customer", conn);
                SqlDataReader sqlReader = cmdSelect.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        aCustomer = new Customer();
                        aCustomer.CustomerId = sqlReader["CustomerId"].ToString();
                        aCustomer.CustomerName = sqlReader["CustomerName"].ToString();
                        aCustomer.StreetAddress= sqlReader["StreetAddress"].ToString();
                        aCustomer.PostalCode= sqlReader["PostalCode"].ToString();
                        aCustomer.CreditLimit = Convert.ToInt32(sqlReader["CreditLimit"]);
                        aCustomer.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                        aCustomer.City = sqlReader["City"].ToString();
                        aCustomer.Province = sqlReader["Province"].ToString();
                        listCustomer.Add(aCustomer);
                    }

                }

                else
                {
                    listCustomer = null;
                }

            }
            return listCustomer;

        }
    }
}
