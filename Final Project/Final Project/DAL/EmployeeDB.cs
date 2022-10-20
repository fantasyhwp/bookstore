using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.BLL;
using System.Data.SqlClient;


namespace Final_Project.DAL
{
    public static class EmployeeDB
    {
        public static List<Employee> ListAllRecords()
        {
            List<Employee> listEmployee = new List<Employee>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Employees ";
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Employee emp;
            while (sqlReader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.JobTitle = sqlReader["JobTitle"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                listEmployee.Add(emp);

            }
            return listEmployee;

        }

        public static void UpdateRecord(Employee employee)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Employees " +
                                    "SET EmployeeId = @EmployeeId," +
                                    "FirstName = @FirstName," +
                                    "LastName = @LastName," +
                                    "Email = @Email," +
                                    "PhoneNumber = @PhoneNumber," +
                                    "JobTitle = @JobTitle " +
                                    "WHERE EmployeeId = @EmployeeId";
            cmdUpdate.Parameters.AddWithValue("@EmployeeId",employee.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdUpdate.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmdUpdate.Parameters.AddWithValue("@Email", employee.Email);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int Id)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM Employees " +
                                    "WHERE EmployeeId = @EmployeeId";
            cmdDelete.Parameters.AddWithValue("@EmployeeId",Id);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
        public static void SaveRecord(Employee employee)
        {
            SqlConnection conn = UtillityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "INSERT INTO Employees(EmployeeId,FirstName,LastName,PhoneNumber,Email,JobTitle) " +
                                    " VALUES (@EmployeeId,@FirstName,@LastName,@PhoneNumber,@Email,@JobTitle)";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", employee.Email);
            cmdInsert.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }
        public static Employee SearchRecord(int Id)
        {
            Employee emp = new Employee();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Employees " +
                                    "WHERE EmployeeId = @EmployeeId";
            cmdSelect.Parameters.AddWithValue("@EmployeeId", Id);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            if (sqlReader.Read()) 
            {
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                emp.JobTitle = sqlReader["JobTitle"].ToString();
            }
            else 
            {
                emp = null;
            }

            return emp;
        }
        public static List<Employee> SearchRecord(string name)
        {
            List<Employee> listEmp = new List<Employee>();
            SqlConnection conn = UtillityDB.ConnectDB();
            conn = UtillityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = "SELECT * FROM Employees " +
                                    "WHERE FirstName = @FirstName " +
                                    " Or LastName = @LastName ";
            cmdSelect.Parameters.AddWithValue("@FirstName", name);
            cmdSelect.Parameters.AddWithValue("@LastName", name);
            cmdSelect.Connection = conn;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Employee emp;

            while (sqlReader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                emp.JobTitle = sqlReader["JobTitle"].ToString();
                listEmp.Add(emp);

            }
            return listEmp;
        }
    }
}
